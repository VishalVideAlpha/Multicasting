# Build stage
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src

# Copy project file and restore dependencies
COPY Client.csproj ./
RUN dotnet restore Client.csproj

# Copy all source files
COPY . ./

# Publish the project
RUN dotnet publish Client.csproj -c Release -o /app/publish

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime
WORKDIR /app

# Copy published files from build stage
COPY --from=build /app/publish ./

# Expose port
EXPOSE 86

# Run the app
ENTRYPOINT ["dotnet", "Client.dll"]
