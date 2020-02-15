#!/usr/bin/env pwsh
# Powershell script for creating Nuget packages
# Note: packages are saved to .packages folder

New-Item -Force -ItemType directory -Path .packages
Remove-Item .packages/*.*

# clean artifacts
&('dotnet') ('clean', '-c', 'Release', 'MarkLogic.Client')
&('dotnet') ('clean', '-c', 'Release', 'dotnet-ml')

# build and package
&('dotnet') ('pack', '-c', 'Release', '-o', '.packages', 'MarkLogic.Client')
if ($LastExitCode -ne 0) { exit $LastExitCode }

&('dotnet') ('pack', '-c', 'Release', '-o', '.packages', 'dotnet-ml')
if ($LastExitCode -ne 0) { exit $LastExitCode }