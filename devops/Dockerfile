# Используем официальный образ .NET SDK для сборки приложения
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# Устанавливаем рабочую директорию
WORKDIR /app

# Копируем csproj и восстанавливаем зависимости
COPY Memo4me.sln ./
COPY src/Core/Memo4me.Application/*.csproj ./src/Core/Memo4me.Application/
COPY src/Core/Memo4me.Domain/*.csproj ./src/Core/Memo4me.Domain/
COPY src/Infrastructure/Memo4me.Persistence/*.csproj ./src/Infrastructure/Memo4me.Persistence/
COPY src/Presentation/Memo4me.API/*.csproj ./src/Presentation/Memo4me.API/
COPY src/Presentation/Memo4me.UI/*.csproj ./src/Presentation/Memo4me.UI/
RUN dotnet restore src/Presentation/Memo4me.API/Memo4me.API.csproj

# Копируем все файлы и собираем приложение
COPY . ./
RUN dotnet publish src/Presentation/Memo4me.API/Memo4me.API.csproj -c Release -o out

# Используем официальный образ .NET Runtime для выполнения приложения
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime

# Устанавливаем рабочую директорию
WORKDIR /app

# Копируем собранное приложение из предыдущего шага
COPY --from=build /app/out ./

# Открываем порт 80 для веб-приложения
EXPOSE 80

# Указываем команду для запуска приложения
ENTRYPOINT ["dotnet", "Memo4me.API.dll"]