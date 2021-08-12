#!/bin/sh

# (re)deploy test database
docker-compose exec deployer /workspace/deploy.sh

# run test script
docker-compose exec testrunner /workspace/run-tests.sh