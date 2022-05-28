FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /app

COPY *.csproj ./
RUN dotnet restore

COPY . ./
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime
RUN apt-get update
RUN apt-get install libreoffice -y

WORKDIR /usr/bin
COPY --from=build /app/out .
ENTRYPOINT ["dotnet", "libreoffice-api.dll"]