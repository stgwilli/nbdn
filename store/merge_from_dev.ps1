if ($args.length -eq 0)
{
  "Please provide a commit message"
  exit
}
git add -A
git commit -m $args[0]
git checkout master
git merge development

