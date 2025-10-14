# Build stage
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src

# Copy all client files
COPY Client/ ./Client/

# Restore dependencies
RUN dotnet restore ./Client/Client.csproj

# Publish the app
RUN dotnet publish ./Client/Client.csproj -c Release -o /app/publish

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime
WORKDIR /app

# Copy published app from build stage
COPY --from=build /app/publish ./

# Expose container port
EXPOSE 86

# Run the app
ENTRYPOINT ["dotnet", "Client.dll"]
