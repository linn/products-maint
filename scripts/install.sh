#!/bin/bash
set -ev

dotnet restore

# upgrade node to latest version
if [ "$CI" ] && [ "$TRAVIS" ]
then 
	source ~/.nvm/nvm.sh; 
	nvm install 8.10.0;
	nvm use 8.10.0;
	npm i -g npm
fi

cd ./src/Service.Host
npm install
npm run build
cd ../..
