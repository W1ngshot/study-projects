FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env
WORKDIR /app

# Копирование проекта в образ
COPY *.csproj ./
RUN dotnet restore

# Копирование всех файлов и сборка проекта
COPY . ./
RUN dotnet publish -c Release -o out

# Конечный образ
FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app
COPY --from=build-env /app/out .

# Установка переменных окружения для подключения к БД
ENV DB_HOST=localhost
ENV DB_PORT=5432
ENV DB_NAME=postgres
ENV DB_USER=postgres
ENV DB_PASSWORD=mysecretpassword

# Открытие порта приложения
EXPOSE 80

# Запуск приложения
ENTRYPOINT ["dotnet", "Jwt.dll"]