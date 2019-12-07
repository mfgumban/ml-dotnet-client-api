#!/usr/bin/env pwsh
# Powershell script for running all tests against the different app servers

$env:MARKLOGIC_HOST = 'localhost'
$env:MARKLOGIC_PORT = 17001
$env:MARKLOGIC_USERNAME = 'admin'
$env:MARKLOGIC_PASSWORD = 'admin'
$env:MARKLOGIC_AUTH = 'SSL'
Write-Output 'Running client library tests against SSL server...'
&('dotnet') ('test', 'MarkLogic.Client.Tests/MarkLogic.Client.Tests.csproj')