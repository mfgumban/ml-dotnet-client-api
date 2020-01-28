# This Dockerfile assumes the build context to be the project root directory
FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS base
WORKDIR /app

# dependencies
COPY *.sln .
COPY dotnet-ml/*.csproj ./dotnet-ml/
COPY MarkLogic.Client/*.csproj ./MarkLogic.Client/
COPY MarkLogic.Client.Tests/*.csproj ./MarkLogic.Client.Tests/
COPY MarkLogic.Client.Tools/*.csproj ./MarkLogic.Client.Tools/
COPY MarkLogic.Client.Tools.Tests/*.csproj ./MarkLogic.Client.Tools.Tests/

RUN dotnet restore

# build
FROM base AS build
WORKDIR /app

COPY dotnet-ml ./dotnet-ml/
COPY MarkLogic.Client ./MarkLogic.Client/
COPY MarkLogic.Client.Tests ./MarkLogic.Client.Tests/
COPY MarkLogic.Client.Tools ./MarkLogic.Client.Tools/
COPY MarkLogic.Client.Tools.Tests ./MarkLogic.Client.Tools.Tests/

RUN dotnet build -c Debug -o out

# run tests
FROM build AS test
WORKDIR /app

CMD dotnet test -c Debug -o out