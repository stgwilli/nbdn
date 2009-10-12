#third_party
$libraries = ("developwithpassion.bdddoc","mbunit","rhino.mocks","developwithpassion.bdd","nhibernate","fluent.nhibernate","castle")

$libraries | foreach-object{ svn export svn://bitwisemaster/thirdparty/open_source/binaries/$_ thirdparty/$_ --force}

$include_library = read-host "Include developwithpassion.commons? (Y/N)"
if ($include_library.ToUpper() -eq "Y")
{
  svn export svn://bitwisemaster/thirdparty/open_source/binaries/developwithpassion.commons thirdparty/developwithpassion.commons --force
}

#commons source
$include_library = read-host "Include developwithpassion common source? (Y/N)"
if ($include_library.ToUpper() -eq "Y")
{
  svn export svn://bitwisemaster/development/projects/developwithpassion.commons/trunk/product product --force
  svn export svn://bitwisemaster/development/projects/developwithpassion.bdd/trunk/product product --force
}

