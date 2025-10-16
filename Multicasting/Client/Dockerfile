# ---------------- Build stage ----------------
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src

# Copy project file and restore dependencies
COPY Client/Client.csproj ./Client/
RUN dotnet restore ./Client/Client.csproj

# Copy all source files
COPY Client/ ./Client/

# Publish the project
RUN dotnet publish ./Client/Client.csproj -c Release -o /app/publish

# ---------------- Runtime stage ----------------
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime
WORKDIR /app

# Copy published files
COPY --from=build /app/publish ./

# Expose port
EXPOSE 86

# Run the application
ENTRYPOINT ["dotnet", "Client.dll"]
