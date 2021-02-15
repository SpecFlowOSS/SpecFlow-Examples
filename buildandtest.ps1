$skipTestExecution = ('*ExternalDataSample\Specs.sln', '*GherkinFormattingExamples\GherkinFormattingExamples.sln')

ForEach ($file in get-childitem . -recurse | where {$_.extension -like "*sln"})
{
	$fullname = $file.fullname
	
	# MSBuild contains old specflow versions, do not touch it
	if (!($fullname -match 'MSBuild'))
	{		
		Write-Output "File name: $file"
		Write-Output "Fullpath: $fullname"	
		
		# dotnet test restores and builds the solution
		if (!(($skipTestExecution | %{$fullname -like $_}) -contains $true))
		{
			iex "dotnet test '$fullname'"
			if ($lastexitcode -ne 0)
			{
				Write-Output $lastexitcode
				break;
			}
		}
		else 
		{
			Write-Output "Test execution of '$fullname' was skipped because it contains failing tests. Building solution."
			
			iex "dotnet build '$fullname'"
			if ($lastexitcode -ne 0)
			{
				break;
			}
		}

		Write-Output "------------------------------------------------------------------------------------------------------------"		
	}
}
