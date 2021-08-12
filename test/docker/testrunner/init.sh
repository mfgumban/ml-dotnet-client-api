#!/bin/sh

# install root CA certificate
echo "Installing root CA certificate..."
mkdir /usr/local/share/ca-certificates/extra
cp /tmp/cert/rootCA.pem /usr/local/share/ca-certificates/extra/rootCA.crt
update-ca-certificates