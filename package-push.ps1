#!/usr/bin/env pwsh
# Powershell script for pushing to Nuget

New-Item -Force -ItemType directory -Path .packages
Remove-Item .packages/*.*

# clean artifacts
&('dotnet') ('clean', '-c', 'Release', 'MarkLogic.Client')
&('dotnet') ('clean', '-c', 'Release', 'dotnet-ml')

# build and package
&('dotnet') ('pack', '-c', 'Release', '-o', '../.packages', 'MarkLogic.Client')
if ($LastExitCode -ne 0) { exit $LastExitCode }

&('dotnet') ('pack', '-c', 'Release', '-o', '../.packages', 'dotnet-ml')
if ($LastExitCode -ne 0) { exit $LastExitCode }

# push to Nuget
$nugetAPIKey = Read-Host 'Enter Nuget API Key'
Get-Item .packages/*.nupkg | ForEach { &('dotnet') ('nuget', 'push', $_.fullname, '-k', $nugetAPIKey, '-s', 'https://api.nuget.org/v3/index.json') }