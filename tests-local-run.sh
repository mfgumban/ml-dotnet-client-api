#!/bin/bash

# (re)deploy test database
cd test
gradle mlDeploy
cd ..

# clear workspace
echo "Clearing old test results..."
[ -d test-results/local ] && rm -r test-results/local
mkdir test-results/local

dotnet restore
dotnet clean -c Debug
dotnet build -c Debug

# run tests
dotnet test MarkLogic.Client.Tests \
  -c Debug --results-directory test-results/local/MarkLogic.Client.Tests --logger "trx;logfilename=test-results.xml" \
  /p:CollectCoverage=true /p:CoverletOutputFormat=opencover /p:CoverletOutput=../test-results/local/MarkLogic.Client.Tests/coverage.opencover.xml \
  /p:Exclude=\"[xunit*]*\"

dotnet test MarkLogic.Client.Tools.Tests \
  -c Debug --results-directory test-results/local/MarkLogic.Client.Tools.Tests --logger "trx;logfilename=test-results.xml" \
  /p:CollectCoverage=true /p:CoverletOutputFormat=opencover /p:CoverletOutput=../test-results/local/MarkLogic.Client.Tools.Tests/coverage.opencover.xml \
  /p:Exclude=\"[xunit*]*,[MarkLogic.Client]*\"

# create coverage report
reportgenerator \
  -reports:test-results/local/MarkLogic.*/coverage.opencover.xml \
  -targetdir:test-results/local/coverage-report -reporttypes:HTMLInline
