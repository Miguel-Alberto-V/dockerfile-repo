#!/bin/bash
mkdir pruebita

docker build -t calculador-interes-compuesto .

# Run the Docker container in detached mode (background)
CONTAINER_ID=$(docker run -it --rm calculador-interes-compuesto)

mkdir app
# Copy the published application files from the container to the local machine
docker cp $CONTAINER_ID:/app ./app

# Stop the container
docker stop $CONTAINER_ID

# Remove the container
docker rm $CONTAINER_ID

