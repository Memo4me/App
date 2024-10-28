# Use the official .NET SDK image to build the application
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

EXPOSE 8080

# Set the working directory
WORKDIR /app

# Copy csproj and restore dependencies
COPY Memo4me.sln ./
COPY src/Core/Memo4me.Application/*.csproj ./src/Core/Memo4me.Application/
COPY src/Core/Memo4me.Domain/*.csproj ./src/Core/Memo4me.Domain/
COPY src/Infrastructure/Memo4me.Persistence/*.csproj ./src/Infrastructure/Memo4me.Persistence/
COPY src/Presentation/Memo4me.API/*.csproj ./src/Presentation/Memo4me.API/
RUN dotnet restore src/Presentation/Memo4me.API/Memo4me.API.csproj

# Copy all the files and build the application
COPY . ./
RUN dotnet publish src/Presentation/Memo4me.API/Memo4me.API.csproj -c Release -o out

# Use the official .NET Runtime image to run the application
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime

# Set the working directory
WORKDIR /app

COPY --from=build /app/out .

# Specify the command to run the application
ENTRYPOINT ["dotnet", "Memo4me.API.dll"]