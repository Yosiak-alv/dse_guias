# syntax=docker/dockerfile:1

# Etapa de build
FROM mcr.microsoft.com/dotnet/sdk:8.0-alpine AS build

# Establecer el directorio de trabajo en /app
WORKDIR /app

# Copiar el archivo de solución y los archivos del proyecto
COPY Desafio1.sln ./
COPY Biblioteca.BL/Biblioteca.BL.csproj Biblioteca.BL/
COPY Biblioteca.Common/Biblioteca.Common.csproj Biblioteca.Common/
COPY Biblioteca.DAL/Biblioteca.DAL.csproj Biblioteca.DAL/
COPY Biblioteca.Entities/Biblioteca.Entities.csproj Biblioteca.Entities/
COPY Desafio1/Desafio1.csproj Desafio1/

# Restaurar dependencias
RUN dotnet restore

# Copiar el resto de los archivos y construir el proyecto
COPY . .
RUN dotnet publish Desafio1/Desafio1.csproj -c Release -o out

# Etapa final
FROM mcr.microsoft.com/dotnet/aspnet:8.0-alpine AS runtime
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT ["dotnet", "Desafio1.dll"]
