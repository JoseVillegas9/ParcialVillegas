# Etapa de build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /app

# Copiar el archivo de proyecto y restaurar dependencias
COPY FutbolPeruano.csproj ./
RUN dotnet restore

# Copiar el resto de archivos y publicar
COPY . ./
RUN dotnet publish -c Release -o out

# Etapa de runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app

# Copiar el resultado del build
COPY --from=build-env /app/out .

# Configurar el nombre del ejecutable
ENV APP_NET_CORE FutbolPeruano.dll

# Comando de inicio que escucha el puerto dinámico que Render asigna
CMD ASPNETCORE_URLS=http://:$PORT dotnet $APP_NET_CORE
