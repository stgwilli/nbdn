function update_powershell{
  $build_scripts = "build_utilities.ps1","psake.ps1","kill_subversion_files.ps1","create_new_project.ps1"

  $current_directory = get-location
  $powershell_path = "$($env:systemroot)\system32\windowspowershell\v1.0"

  update_path_environment_variable_with $powershell_path
  copy_build_scripts_to $current_directory $powershell_path
}

function copy_build_scripts_to($current_directory,$destination){
  $build_scripts | foreach-object{
    [System.IO.File]::Copy("$current_directory\$_","$destination\$_",$true)
  }
}

function update_path_environment_variable_with($powershell_path){
  if (! $env:path.ToLower().Contains($powershell_path.ToLower()))
  {
    [System.Environment]::SetEnvironmentVariable("PATH",$env:path + $powershell_path,"MACHINE")
  }
}

update_powershell
"Updated powershell to work as a build tool"
