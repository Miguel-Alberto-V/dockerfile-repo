# Usa la imagen oficial del SDK de .NET 8.0 como base para el entorno de construcción
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env

# Establece el directorio de trabajo en /App
WORKDIR /App

# Crea un nuevo proyecto de consola
RUN dotnet new console -o DotNet.Docker

# Copia el archivo Program.cs al directorio del proyecto
COPY Program.cs DotNet.Docker/Program.cs

# Cambia al directorio del proyecto
WORKDIR /App/DotNet.Docker

# Restaura las dependencias, compila y publica la aplicación en modo Release en la carpeta /App/out
RUN dotnet publish -c Release -o /App/out

# Usa la imagen oficial de ASP.NET 8.0 como base para el entorno de ejecución
FROM mcr.microsoft.com/dotnet/aspnet:8.0

# Establece el directorio de trabajo en /App
WORKDIR /App

# Copia los archivos publicados desde el contenedor de construcción al contenedor de ejecución
COPY --from=build-env /App/out .

# Establece el punto de entrada para el contenedor, ejecutando la aplicación publicada
ENTRYPOINT ["dotnet", "DotNet.Docker.dll"]
