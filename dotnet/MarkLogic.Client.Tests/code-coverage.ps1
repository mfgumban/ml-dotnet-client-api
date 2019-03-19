# Powershell script to run code coverage and generate report

$coverageDir = 'coverage/*.*'
if (Test-Path $coverageDir) {
  Remove-Item -Path $coverageDir
}

&('dotnet') ('test', `
  '/p:CollectCoverage=true', `
  '/p:CoverletOutputFormat=opencover', `
  '/p:CoverletOutput=coverage/coverage.opencover.xml', `
  '/p:Exclude=\"[xunit*]*\"')

if ($LastExitCode -ne 0) { exit $LastExitCode }

&('dotnet') ('reportgenerator', `
    '-reports:coverage/coverage.opencover.xml', `
    '-targetdir:coverage', `
    '-reporttypes:HTMLInline')
  
if ($LastExitCode -ne 0) { exit $LastExitCode }

Start-Process 'coverage/index.htm'