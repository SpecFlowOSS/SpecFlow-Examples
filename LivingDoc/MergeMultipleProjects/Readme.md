# Example: Generating one Living Documentation for multiple Projects

This examples shows you how to generate one Living Documentation for multiple projects.

The important part is the `RunAndMerge.ps1` PowerShell Script.

Here is what it does:

> dotnet test

Run all tests of the solution. This generates a TestExecution.json for each project

> $testExecutionJsonProjectA = "./SpecA/bin/Debug/net6.0/TestExecution.json"
(Get-Content $testExecutionJsonProjectA).Replace("`"FeatureFolderPath`":`"","`"FeatureFolderPath`":`"SpecA/") | Set-Content $testExecutionJsonProjectA

This adjusts the TestExecution.json of Project SpecA so that at the end, you the test results are correctly matched. In this case, you just need to add the path "SpecA" to every `FeatureFolderPath` in the TestExecution.jsons.

> $testExecutionJsonProjectB = "./SpecB/bin/Debug/net6.0/TestExecution.json"
(Get-Content $testExecutionJsonProjectB).Replace("`"FeatureFolderPath`":`"","`"FeatureFolderPath`":`"SpecB/") | Set-Content $testExecutionJsonProjectB

This adjusts the TestExecution.json of Project SpecB so that at the end, you the test results are correctly matched. In this case, you just need to add the path "SpecB" to every `FeatureFolderPath` in the TestExecution.jsons.

> livingdoc feature-folder . -t .\SpecA\bin\Debug\net6.0\TestExecution.json .\SpecB\bin\Debug\net6.0\TestExecution.json

With the adjusted paths in the TestExecution.json you can call the `livingdoc` command in the root of your solution and get Test results in your Living Documentation.