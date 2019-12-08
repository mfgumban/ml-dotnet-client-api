#!/usr/bin/env pwsh
# Powershell script for setting up test servers in Docker

&('docker-compose') ('up', '-d')
Start-Sleep -s 30
#&('docker') ('exec', '-it', 'mltestdotnet', 'init-marklogic')
#Start-Sleep -s 5

Push-Location -Path './test'
try { 
    &('gradle') ('mlDeploy')
    Start-Sleep -s 5
    &('gradle') ('installCertificate')
}
finally { Pop-Location }
