dotnet test

$testExecutionJsonProjectA = "./SpecA/bin/Debug/net6.0/TestExecution.json"
(Get-Content $testExecutionJsonProjectA).Replace("`"FeatureFolderPath`":`"","`"FeatureFolderPath`":`"SpecA/") | Set-Content $testExecutionJsonProjectA

$testExecutionJsonProjectB = "./SpecB/bin/Debug/net6.0/TestExecution.json"
(Get-Content $testExecutionJsonProjectB).Replace("`"FeatureFolderPath`":`"","`"FeatureFolderPath`":`"SpecB/") | Set-Content $testExecutionJsonProjectB


livingdoc feature-folder . -t .\SpecA\bin\Debug\net6.0\TestExecution.json .\SpecB\bin\Debug\net6.0\TestExecution.json