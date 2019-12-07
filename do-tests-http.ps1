#!/usr/bin/env pwsh
# Powershell script for running all tests against the different app servers

$env:MARKLOGIC_HOST = 'localhost'
$env:MARKLOGIC_PORT = 17000
$env:MARKLOGIC_USERNAME = 'admin'
$env:MARKLOGIC_PASSWORD = 'admin'
Write-Output 'Running client library tests against HTTP server...'
&('dotnet') ('test', 'MarkLogic.Client.Tests/MarkLogic.Client.Tests.csproj')