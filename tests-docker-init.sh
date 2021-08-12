#!/bin/sh

cd test/cert
./create-certs.sh

cd ../..
docker-compose up -d -V