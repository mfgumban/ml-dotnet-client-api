#!/bin/sh
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
gradle -PmlHost=$ML_HOST -PmlUsername=$ML_USER -P mlPassword=$ML_PWD mlDeploy

# generate certificate request
cd ..
[ -d cert ] && rm -r cert
mkdir cert
cd cert
echo "Generating a certificate request from ML..."
curl --anyauth -u admin:admin -o ml.csr -H "Content-Type: application/json" \
  -d '{ "operation": "generate-certificate-request", "common-name": "ml" }' \
  -X POST http://ml:8002/manage/v2/certificate-templates/ml-dotnet-client-api-tests-template

# create certificate from request
echo "Creating host certificate..."
cp /tmp/cert/rootCA.* .
cp /tmp/cert/ml.ext .
openssl x509 -req -in ml.csr -CA rootCA.pem -CAkey rootCA.key -CAcreateserial -out ml.crt -days 3650 -sha256 -extfile ml.ext -passin pass:1234

# register certificate on ML
echo "Registering host certificate in ML..."
curl --anyauth -u admin:admin --data-binary @ml.crt -H "Content-Type: text/plain" -X POST http://ml:8002/manage/v2/certificates

echo "End deployment to $ML_HOST"
