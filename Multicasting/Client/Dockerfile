# Build stage
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src

# Copy only the project files first to optimize caching
COPY Client/Client/*.csproj ./Client/
RUN dotnet restore Client/Client.csproj

# Copy the rest of the source code
COPY Client/Client/ ./Client/

# Publish the project to /app/publish
RUN dotnet publish Client/Client.csproj -c Release -o /app/publish

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime
WORKDIR /app

# Copy published files from the build stage
COPY --from=build /app/publish ./

# Expose port
EXPOSE 86

# Run the application
ENTRYPOINT ["dotnet", "Client.dll"]
