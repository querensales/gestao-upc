#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.


# Use a imagem base do .NET 8 SDK para construir a aplicação
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /app

# Copia o arquivo de projeto e restaura as dependências
COPY *.csproj ./
RUN dotnet restore "../"

# Copia o resto do código fonte
COPY . ./

# Publica a aplicação
RUN dotnet publish -c Release -o out

# Use uma imagem base menor para o runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build-env /app/out ./

# Expõe a porta que a API usa (normalmente 80)
EXPOSE 81

# Define o ponto de entrada para a aplicação
ENTRYPOINT ["dotnet", "WebApi.dll"] # Substitua MinhaApiDotNet8 pelo nome do seu assembly

#FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
#USER app
#WORKDIR /app
#EXPOSE 8080
#EXPOSE 8081
#
#FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
#ARG BUILD_CONFIGURATION=Release
#WORKDIR /src
#COPY ["WebApi.csproj", "./WebApi/"]
#RUN dotnet restore "./WebApi/WebApi.csproj" --force
#COPY . .
#WORKDIR "/src/WebApi"
#RUN dotnet build "./WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/build
#
#FROM build AS publish
#ARG BUILD_CONFIGURATION=Release
#RUN dotnet publish "./WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false
#
#FROM base AS final
#WORKDIR /app
#COPY --from=publish /app/publish .
#ENTRYPOINT ["dotnet", "WebApi.dll"]