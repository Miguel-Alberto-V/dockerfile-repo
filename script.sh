#!/bin/bash

docker build -t webapipokemon .

docker run -d -p 8080:80 webapipokemon


