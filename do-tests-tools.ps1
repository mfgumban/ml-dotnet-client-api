#!/usr/bin/env pwsh
# Powershell script for running all tests against the different app servers

# Tools tests
Write-Output 'Running tools tests...'
&('dotnet') ('test', 'MarkLogic.Client.Tools.Tests/MarkLogic.Client.Tools.Tests.csproj')