$skipTestExecution = ('*ExternalDataSample\Specs.sln', '*GherkinFormattingExamples\GherkinFormattingExamples.sln', '*WinForms\WinForms.sln', '*WPF\WPF.sln', '*Android Mobile App\Android Mobile App.sln')

function Get-MSBuild
{
    If ($vsWhere = Get-Command "vswhere.exe" -ErrorAction SilentlyContinue) 
    {
        $vsWhere = $vsWhere.Path
    } 
    ElseIf (Test-Path "${env:ProgramFiles(x86)}\Microsoft Visual Studio\Installer\vswhere.exe") 
    {
        $vsWhere = "${env:ProgramFiles(x86)}\Microsoft Visual Studio\Installer\vswhere.exe"
    }
    Else 
    {
        Write-Error "vswhere not found. Aborting." -ErrorAction Stop
    }

    Write-Host "vswhere found at: $vsWhere" -ForegroundColor Yellow

    $path = &$vsWhere -prerelease -latest -products * -requires Microsoft.Component.MSBuild -find MSBuild\**\Bin\MSBuild.exe

    Write-Host "MSBuild found at: $path" -ForegroundColor Yellow

    return $path
}Invoke-Expression "dotnet restore 'C:\Users\jorwe\source\repos\SpecFlow-Examples\.NET 6\Android Mobile App\Android Mobile App.sln'"

ForEach ($file in get-childitem . -recurse | where {$_.extension -like "*sln"})
{
	$fullname = $file.fullname
	
	# MSBuild contains old specflow versions, do not touch it
	if (!($fullname -match 'MSBuild') -And !($fullname -match 'Webinars'))
	{		
		Write-Output "File name: $file"
		Write-Output "Fullpath: $fullname"	
		
		# dotnet test restores and builds the solution
		if (!(($skipTestExecution | %{$fullname -like $_}) -contains $true))
		{
			# it has a local nuget feed, so build the nuget package first
			if ($fullname -match 'SampleMethodTagDecorator')
			{
				$generatorPlugin = $fullname.Replace('SampleMethodTagDecorator.sln', 'GeneratorPlugin\SampleGeneratorPlugin.csproj')
				Write-Output $generatorPlugin
				iex "dotnet build '$generatorPlugin'"
			}

		    iex "dotnet test '$fullname'"

			if ($lastexitcode -ne 0)
			{
				break;
			}	
		}
		else 
		{
			Write-Output "Test execution of '$fullname' was skipped because it contains failing tests. Building solution."
			
			if ($fullname -match 'Android Mobile App.sln') 
			{
				Invoke-Expression "dotnet restore '$fullname'"
				$msbuild = Get-MSBuild
				$expression = "& '$msbuild' -restore '$fullname'"
				Invoke-Expression $expression
			}
			else 
			{
				iex "dotnet test '$fullname'"
			}

			if ($lastexitcode -ne 0)
			{
				break;
			}
		}

		Write-Output "------------------------------------------------------------------------------------------------------------"		
	}
}