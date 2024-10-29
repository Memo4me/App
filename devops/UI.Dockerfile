# Use the official .NET SDK image to build the Blazor app
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

EXPOSE 8080

# Set the working directory
WORKDIR /app

# Copy csproj and restore dependencies
COPY Memo4me.sln ./ 
COPY src/Presentation/Memo4me.UI/*.csproj ./src/Presentation/Memo4me.UI/
RUN dotnet restore src/Presentation/Memo4me.UI/Memo4me.UI.csproj

# Copy all the files and build the application
COPY . .
RUN dotnet publish src/Presentation/Memo4me.UI/Memo4me.UI.csproj -c Release -o out

# Use the official .NET ASP.NET runtime image to run the Blazor app
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime

# Set the working directory
WORKDIR /app

# Copy the build output
COPY --from=build /app/out .

# Specify the command to run the Blazor app
ENTRYPOINT ["dotnet", "Memo4me.UI.dll"]