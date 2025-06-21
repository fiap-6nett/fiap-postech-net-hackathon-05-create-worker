# Imagem base do ambiente de runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8090

# Imagem para build da aplicação
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copia o arquivo da solução
COPY FastTechFoods.Worker.sln .

# Copia os arquivos dos projetos
COPY FastTechFoods.Worker.Service/FastTechFoods.Worker.Service.csproj FastTechFoods.Worker.Service/
COPY FastTechFoods.Worker.Application/FastTechFoods.Worker.Application.csproj FastTechFoods.Worker.Application/
COPY FastTechFoods.Worker.Domain/FastTechFoods.Worker.Domain.csproj FastTechFoods.Worker.Domain/
COPY FastTechFoods.Worker.Infra/FastTechFoods.Worker.Infra.csproj FastTechFoods.Worker.Infra/

# Restaura os pacotes NuGet
RUN dotnet restore FastTechFoods.Worker.sln

# Copia o restante dos arquivos
COPY . .

# Compila o projeto
WORKDIR /src/FastTechFoods.Worker.Service
RUN dotnet build -c $BUILD_CONFIGURATION -o /app/build

# Publica a aplicação
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Imagem final com o runtime e a aplicação publicada
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "FastTechFoods.Worker.Service.dll"]
