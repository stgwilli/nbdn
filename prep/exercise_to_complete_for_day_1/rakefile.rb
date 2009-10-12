require 'build_utilities.rb'
require 'local_properties.rb'
require 'project.rb'
require 'rake/clean'
require 'fileutils'

#load settings that differ by machine
local_settings = LocalSettings.new

COMPILE_TARGET = 'debug'

CLEAN.include('artifacts','**/bin','**/obj','**/*.sql')

def create_sql_fileset(folder)
  FileList.new(File.join('product','sql',folder,'**/*.sql'))
end

template_files = TemplateFileList.new('**/*.template')
template_code_dir = File.join('product','templated_code')

sql_runner = SqlRunner.new :sql_tool => local_settings[:osql_exe] , :connection_string => local_settings[:osql_connectionstring]


#configuration files
config_files = FileList.new(File.join('product','config','*.template')).select{|fn| ! fn.include?('app.config')}
app_config = TemplateFile.new(File.join('product','config',local_settings[:app_config_template]))

#target folders that can be run from VS
project_startup_dir  = File.join('product',"#{Project.startup_dir}")
project_test_dir  = File.join('product',"#{Project.tests_dir}",'bin','debug')

output_folders = [project_startup_dir,project_test_dir]

task :default => [:build_db,:full_test]

task :purge_svn do
end

task :init  => :clean do
  mkdir 'artifacts'
  mkdir 'artifacts/coverage'
  mkdir 'artifacts/deploy'
end

desc 'expands all of the template files in the project'
task :expand_all_template_files do
  template_files.generate_all_output_files(local_settings.settings)
end

desc 'builds the database'
task :build_db => :expand_all_template_files do
    sql_runner.process_sql_files(create_sql_fileset('ddl'))
end

desc 'load the database'
task :load_data => :build_db do
    sql_runner.process_sql_files(create_sql_fileset('data'))
end

desc 'compiles the project'
task :compile => :expand_all_template_files do
  MSBuildRunner.compile :compile_target => COMPILE_TARGET, :solution_file => 'solution.sln'
end

desc 'info'
task :info do
  puts Project.name
end

desc 'run the tests for the project'
task :test, :category_to_exclude, :needs => [:compile] do |t,args|
  puts Project.startup_dir
  args.with_defaults(:category_to_exclude => 'SLOW')
  runner = MbUnitRunner.new :compile_target => COMPILE_TARGET, :category_to_exclude => args.category_to_exclude, :show_report => true, :report_type => 'TEXT'
  runner.execute_tests ["#{Project.tests_dir}"]
end

desc 'run the bdddoc test report for the project'
task :run_test_report => [:test] do
 runner = BDDDocRunner.new
 runner.run(File.join('product',"#{Project.tests_dir}",'bin','debug',"#{Project.tests_dir}.dll"))
end

desc 'outputs a compiled version of the program to the artifacts/deploy folder'
task :deploy => [:init,:compile] do
  copy_project_outputs(File.join('artifacts','deploy'),['*.dll','*.exe'])
end


task :from_ide do
  app_config.generate_to(File.join(project_startup_dir,"#{Project.startup_config}"),local_settings.settings)
  app_config.generate_to(File.join(project_test_dir,"#{Project.tests_dir}.dll.config"),local_settings.settings)

  config_files.each do |file|
    TemplateFile.new(file).generate_to_directories([project_startup_dir,project_test_dir],local_settings.settings)
  end
end

def remove_svn_files_from_folder(folder)
    Dir.glob(File.join(folder,'**','.svn')).each do|scratch_folder|
      FileUtils.remove_dir(scratch_folder, :force => true)
    end
end

def copy_project_outputs(folder,extensions)
  extensions.each do |extension|
    Dir.glob(File.join('product','**',"#{Project.name}#{extension}")).each do |file|
      FileUtils.cp file,folder
    end
  end
end
