param($message,$working_branch="master",$branch_to_merge="development")

. .\git_utils.ps1

commit -message $message
merge -working_branch $working_branch -branch_to_merge $branch_to_merge
push -branch $working_branch
git checkout $branch_to_merge


