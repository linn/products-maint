#!/bin/bash
set -ev

dotnet restore

# upgrade node to latest version
if [ "$CI" ] && [ "$TRAVIS" ]
then 
	source ~/.nvm/nvm.sh; 
	nvm install 6;
	nvm use 6;
fi

cd ./src/Service.Host
npm config set '@bit:registry' https://node.bitsrc.io
npm install
npm run build
cd ../..
