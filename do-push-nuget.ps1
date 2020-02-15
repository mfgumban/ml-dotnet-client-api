#!/usr/bin/env pwsh
# Powershell script for pushing packages to Nuget
# Note: this script assumes packages have been prepared using do-pack.ps1

# push to Nuget
$nugetAPIKey = Read-Host 'Enter Nuget API Key'
Get-Item .packages/*.nupkg | ForEach { &('dotnet') ('nuget', 'push', $_.fullname, '-k', $nugetAPIKey, '-s', 'https://api.nuget.org/v3/index.json') }