#!/usr/bin/env pwsh
# Powershell script for running all tests against the different app servers

# Tools tests
Write-Output 'Running tools tests...'
&('dotnet') ('test', 'MarkLogic.Client.Tools.Tests/MarkLogic.Client.Tools.Tests.csproj')

# HTTP tests
$env:MARKLOGIC_HOST = 'localhost'
$env:MARKLOGIC_PORT = 17000
$env:MARKLOGIC_USERNAME = 'admin'
$env:MARKLOGIC_PASSWORD = 'admin'
Write-Output 'Running client library tests against HTTP...'
&('dotnet') ('test', 'MarkLogic.Client.Tests/MarkLogic.Client.Tests.csproj')

# HTTP tests
$env:MARKLOGIC_HOST = 'localhost'
$env:MARKLOGIC_PORT = 17001
$env:MARKLOGIC_USERNAME = 'admin'
$env:MARKLOGIC_PASSWORD = 'admin'
Write-Output 'Running client library tests against HTTPS/SSL...'
&('dotnet') ('test', 'MarkLogic.Client.Tests/MarkLogic.Client.Tests.csproj')