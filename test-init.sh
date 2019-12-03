#!/bin/bash

echo "Running docker-compose up..."
docker-compose up -d

echo "Initializing mlhttp..."
docker exec -it mlhttp.local init-marklogic

echo "Initializing mlhttps..."
docker exec -it mlhttps.local init-marklogic

echo "Done."