$shell_new_path = "Registry::HKEY_CLASSES_ROOT\.sln\ShellNew"
copy-item "Visual Studio Solution.sln" C:\windows\Shellnew -force
$key_exists = test-path -path $shell_new_path

if ($key_exists -eq $false)
{
  new-item -path $shell_new_path
  new-itemproperty -path $shell_new_path -Name FileName -PropertyType String -Value "Visual Studio Solution.sln"
}
"Created the registry key for creating studio solutions"
