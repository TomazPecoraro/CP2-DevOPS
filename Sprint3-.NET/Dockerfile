# Usar a imagem do SDK para build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /app

# Copiar e restaurar dependências
COPY Sprint3-.NET.sln .
COPY Sprint3.API/Sprint3.API.csproj Sprint3.API/
COPY Sprint3.Models/Sprint3.Models.csproj Sprint3.Models/
COPY Sprint3.Database/Sprint3.Database.csproj Sprint3.Database/
COPY Sprint3.Service/Sprint3.Service.csproj Sprint3.Service/
COPY Sprint3.Repository/Sprint3.Repository.csproj Sprint3.Repository/

RUN dotnet restore

# Copiar o restante do código e construir
COPY . ./
RUN dotnet publish -c Release -o out

# Usar a imagem do runtime para executar
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "Sprint3.API.dll"]

EXPOSE 80

