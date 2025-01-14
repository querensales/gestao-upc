#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.


# Use a imagem base do .NET 8 SDK para construir a aplicação
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /app

# Copia o arquivo de projeto e restaura as dependências
COPY *.sln .
COPY ./AppService/AppService.csproj ./AppService/
COPY ./AppService.Application/AppService.Application.csproj ./AppService.Application/
COPY ./Repository/Repository.csproj ./Repository/
COPY ./WebApi/WebApi.csproj ./WebApi/
RUN dotnet restore 

# Copia o resto do código fonte
COPY . ./

# Publica a aplicação
RUN dotnet publish -c Release -o out

# Use uma imagem base menor para o runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build-env /app/out ./

# Expõe a porta que a API usa (normalmente 80)
EXPOSE 5223
ENV ASPNETCORE_URLS=http://+:5223


# Define o ponto de entrada para a aplicação
ENTRYPOINT ["dotnet", "WebApi.dll"] # Substitua MinhaApiDotNet8 pelo nome do seu assembly