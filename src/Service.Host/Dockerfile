﻿FROM microsoft/dotnet:2.1-runtime

ARG gitBranch=unspecified

EXPOSE 5050

COPY bin/release/netcoreapp2.1/publish/ /app/bin/
COPY client/build/ /app/client/build/
# COPY client/assets/ /app/client/assets/
COPY views/ /app/views/
     
ENV APP_PATH /app/
ENV GIT_BRANCH $gitBranch
ENV TZ UTC

CMD dotnet /app/bin/Linn.Products.Service.Host.dll