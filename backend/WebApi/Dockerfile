# Etapa de build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copia os arquivos de projeto de todas as camadas
COPY AppService/*.csproj ./AppService/
COPY AppService.Application/*.csproj ./AppService.Application/
COPY Repository/*.csproj ./Repository/
COPY WebApi/WebApi.csproj ./WebApi/

# Restaura as dependências
RUN dotnet restore ./WebApi/WebApi.csproj

# Copia todo o código fonte
COPY AppService ./AppService
COPY AppService.Application ./AppService.Application
COPY Repository ./Repository
COPY WebApi ./WebApi

WORKDIR /src/WebApi

# Publica a aplicação
RUN dotnet publish -c Release -o /app/publish

# Etapa de runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .
EXPOSE 80
ENTRYPOINT ["dotnet", "WebApi.dll"]