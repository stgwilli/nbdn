param($remote,$branch_to_pull_to="development",$remote_branch="master")

. .\git_utils.ps1

if ($remote -eq $null)
{ 
  "Usage -- pull [remotename]"
  exit 
}
commit
git checkout -b $branch_to_pull_to
if ($LastExitCode -eq 128) { git checkout $branch_to_pull_to }
git pull $remote $remote_branch
