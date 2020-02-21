#!/bin/bash
# expected directories: /workspace, /tmp/solution (read-only), /tmp/test-results

# set working directory
cd /workspace

echo "Start test run"

# clear workspace
echo "Clearing temporary solution directory..."
[ -d solution ] && rm -r solution

# copy solution files
mkdir solution
PROJECTS=("MarkLogic.Client" "MarkLogic.Client.Tests" "MarkLogic.Client.Tools" "MarkLogic.Client.Tools.Tests" "dotnet-ml")
for project in "${PROJECTS[@]}"; do 
  echo "Copying $project..."
  cp -r /tmp/solution/$project ./solution
done
echo "Copying solution file..."
cp /tmp/solution/*.sln ./solution

# copy required test resources
echo "Copying test resources..."
mkdir solution/test
cp -r /tmp/solution/test/src ./solution/test

# build
echo "Building solution..."
cd /workspace/solution
dotnet restore
dotnet clean -c Debug
dotnet build -c Debug

# run tests
echo "Clearing old test results..."
[ -d /tmp/test-results/docker ] && rm -r /tmp/test-results/docker
mkdir /tmp/test-results/docker

# tools tests
PROJECT=MarkLogic.Client.Tools.Tests
dotnet test $PROJECT \
  -c Debug --results-directory /tmp/test-results/docker/$PROJECT --logger "trx;logfilename=test-results.xml" \
  /p:CollectCoverage=true /p:CoverletOutputFormat=opencover /p:CoverletOutput=coverage.opencover.xml \
  /p:Exclude=\"[xunit*]*,[MarkLogic.Client]*\"
cp $PROJECT/coverage.opencover.xml /tmp/test-results/docker/$PROJECT

# HTTP tests
PROJECT=MarkLogic.Client.Tests
PROJECT_TESTOUT=$PROJECT
cp /tmp/solution/test/docker/testrunner/settings.http.json $PROJECT/settings.json
dotnet test $PROJECT \
  -c Debug --results-directory /tmp/test-results/docker/$PROJECT_TESTOUT --logger "trx;logfilename=test-results.xml" \
  /p:CollectCoverage=true /p:CoverletOutputFormat=opencover /p:CoverletOutput=coverage.opencover.xml \
  /p:Exclude=\"[xunit*]*\"
cp $PROJECT/coverage.opencover.xml /tmp/test-results/docker/$PROJECT_TESTOUT

# SSL / HTTPS tests
PROJECT=MarkLogic.Client.Tests
PROJECT_TESTOUT=$PROJECT.SSL
cp /tmp/solution/test/docker/testrunner/settings.https.json $PROJECT/settings.json
dotnet test $PROJECT \
  -c Debug --results-directory /tmp/test-results/docker/$PROJECT_TESTOUT --logger "trx;logfilename=test-results.xml" \
  /p:CollectCoverage=true /p:CoverletOutputFormat=opencover /p:CoverletOutput=coverage.opencover.xml \
  /p:Exclude=\"[xunit*]*\"
cp $PROJECT/coverage.opencover.xml /tmp/test-results/docker/$PROJECT_TESTOUT

# create coverage report
reportgenerator -reports:/tmp/test-results/docker/MarkLogic.*/coverage.opencover.xml \
  -targetdir:/tmp/test-results/docker/coverage-report -reporttypes:HTMLInline


echo "End test run"