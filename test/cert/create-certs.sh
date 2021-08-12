#!/bin/sh

echo "Creating CA and certificates..."
echo "Removing old files..."
rm *.key *.pem

# root CA private key
openssl genrsa -aes256 -out rootCA.key -passout pass:1234 1024

# root CA certificate
openssl req -x509 -new -nodes -key rootCA.key -sha256 -days 3650 \
  -passin pass:1234 -out rootCA.pem \
  -subj "/C=US/ST=VA/L=McLean/O=MarkLogic/OU=Presales/CN=ml-dotnet-client-api Test CA/emailAddress=nobody@marklogic.com"

# server "ml" private key
#openssl genrsa -aes256 -out ml.key -passout pass:1234 1024

# server "ml" CSR
#openssl req -new -key ml.key -out ml.csr -passin pass:1234 \
#  -subj "/C=US/ST=VA/L=McLean/O=MarkLogic/OU=Presales/CN=ml-dotnet-client-api Test CA/emailAddress=nobody@marklogic.com"

# create certificate for server "ml"
#openssl x509 -req -in ml.csr -CA rootCA.pem -CAkey rootCA.key -CAcreateserial \
#  -out ml.crt -days 3650 -sha256 -extfile ml.ext -passin pass:1234

echo "CA and certificates created."

