#!/bin/bash
# expected environment vars: ML_HOST, ML_USER, ML_PWD
# expected directories: /workspace, /tmp/project (read-only)

# set working directory
cd /workspace

echo "Start deployment to $ML_HOST"

# clear workspace
echo "Clearing temporary project directory..."
[ -d project ] && rm -r project

# copy gradle project from host
echo "Copying project from host..."
mkdir project
cp -r /tmp/project/test/* ./project

# wait for MarkLogic server to be available 
TIMEOUT_SEC=300
WAIT_SEC=10
WAIT_START=$(date +%s)
WAIT_HOST_PORT=8001 # use admin port
until curl --silent --fail --output /dev/null --anyauth -u $ML_USER:$ML_PWD http://$ML_HOST:$WAIT_HOST_PORT
do
  if [ $(($(date +%s) - $WAIT_START)) -gt $TIMEOUT_SEC ]; then
    echo "Waited for MarkLogic server at $ML_HOST for $TIMEOUT_SEC seconds but no response, aborting."
    exit 1
  fi
  echo "Waiting for MarkLogic server at $ML_HOST..."
  sleep $WAIT_SEC
done
echo "MarkLogic server online at $ML_HOST."

# deploy
echo "Starting Gradle deployment..."
cd project
gradle -PmlHost=$ML_HOST -PmlUsername=$ML_USER -P mlPassword=$ML_PWD installCertificate
gradle -PmlHost=$ML_HOST -PmlUsername=$ML_USER -P mlPassword=$ML_PWD mlDeploy

echo "End deployment to $ML_HOST"
