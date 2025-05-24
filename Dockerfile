# Etapa 1: Build
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /app

# Copia todo desde la raíz del repositorio
COPY . .

# Restaurar dependencias y compilar
RUN dotnet restore
RUN dotnet publish -c Release -o /out

# Etapa 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /app
COPY --from=build /out ./

EXPOSE 80
ENTRYPOINT ["dotnet", "Practica3-JeanEstrada.dll"]
