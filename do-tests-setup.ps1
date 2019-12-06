#!/usr/bin/env pwsh
# Powershell script for setting up test servers in Docker

&('docker-compose') ('up', '-d')
&('docker') ('exec', '-it', 'mltestdotnet.local', 'init-marklogic')
