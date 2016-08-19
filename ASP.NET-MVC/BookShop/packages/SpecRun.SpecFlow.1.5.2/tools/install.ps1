param($installPath, $toolsPath, $package, $project)

$project.ProjectItems.Item("Default.srprofile").Properties.Item("CopyToOutputDirectory").Value = 2

