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
PROJECT=MarkLogic.Client.Tests
dotnet test $PROJECT \
  -c Debug --results-directory test-results/local/$PROJECT --logger "trx;logfilename=test-results.xml" \
  /p:CollectCoverage=true /p:CoverletOutputFormat=opencover /p:CoverletOutput=../test-results/local/$PROJECT/coverage.opencover.xml \
  /p:Exclude=\"[xunit*]*\"
reportgenerator -reports:test-results/local/$PROJECT/coverage.opencover.xml -targetdir:test-results/local/$PROJECT/coverage-report -reporttypes:HTMLInline


PROJECT=MarkLogic.Client.Tools.Tests
dotnet test $PROJECT \
  -c Debug --results-directory test-results/local/$PROJECT --logger "trx;logfilename=test-results.xml" \
  /p:CollectCoverage=true /p:CoverletOutputFormat=opencover /p:CoverletOutput=../test-results/local/$PROJECT/coverage.opencover.xml \
  /p:Exclude=\"[xunit*]*,[MarkLogic.Client]*\"
reportgenerator -reports:test-results/local/$PROJECT/coverage.opencover.xml -targetdir:test-results/local/$PROJECT/coverage-report -reporttypes:HTMLInline
