#!/usr/bin/env pwsh
# Powershell script for pushing packages to a local (Nuget) directory.  Primarily used during development testing.
# Note: this script assumes packages have been prepared using do-pack.ps1
# Note: this script assumes the local Nuget repository directory to be ../local-nuget-repo

Get-Item .packages/*.nupkg | ForEach { Copy-Item -Path $_.FullName -Destination "../local-nuget-repo" -Force }