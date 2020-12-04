FROM mcr.microsoft.com/dotnet/sdk:5.0-alpine AS build

WORKDIR /app

COPY *.csproj ./
RUN dotnet restore

COPY . ./

RUN dotnet publish -o publish

FROM mcr.microsoft.com/dotnet/aspnet:5.0-alpine AS runtime

WORKDIR /app

COPY --from=build /app/publish ./

CMD dotnet DockerContainerAppTwo.dll