properties {#load in the build utilities file
  . .\build_utilities.ps1
}

properties{#directories
  $original_location = get-location
  $local_settings = @{
  }

  "Please choose a name for the new project"
  $local_settings.project_name = read-host
  "Please choose a folder where the new project folder will be created?"
  $base_dir = read-host
  $base_dir = "$base_dir\$($local_settings.project_name)"
  
  $build_dir = $base_dir
	$product_dir = "$base_dir\product"
	$sql_dir = "$product_dir\sql"

}

properties{#filesets
  
}
task default -depends init,scaffold,expand_file_contents,expand_file_and_folder_names

task init {
  new-item $base_dir -type directory
  svn export svn://bitwisemaster/development/projects/builds/trunk $build_dir --force
  svn export svn://bitwisemaster/development/tools/new_project_skeleton $base_dir --force
}

task scaffold{
  set-location $build_dir
  . $build_dir\update_externals.ps1
  set-location $original_location
}

task expand_file_contents{
$base_template_files = get_file_names(get-childitem -path $base_dir -filter "*.template")
$product_template_files = get_file_names(get-childitem -path $product_dir -recurse -filter "*csproj.template")


  expand_all_template_files $base_template_files $local_settings
  expand_all_template_files $product_template_files $local_settings

  $base_template_files | foreach-object {remove-item -path $_ -force -ErrorAction SilentlyContinue}
  $product_template_files | foreach-object {remove-item -path $_ -force -ErrorAction SilentlyContinue}
}

task expand_file_and_folder_names{
  $template_items = get_file_names(get-childitem -path $base_dir -recurse -filter "@project_name@*")

  $template_items | foreach-object {
    $item_name = $_
    $item_name = $item_name.Replace("@project_name@",$local_settings.project_name)

    $item_name = [System.IO.Path]::GetFileName($item_name)

    if ([System.IO.File]::Exists($_))
    {
      rename-item -path $_ $item_name
    }
  }

  $template_items | foreach-object {
    $item_name = $_
    $item_name = $item_name.Replace("@project_name@",$local_settings.project_name)

    if ([System.IO.Directory]::Exists($_))
    {
      [System.IO.Directory]::Move($_,$item_name)
      #rename-item -path $_ $item_name
    }
  }

}


