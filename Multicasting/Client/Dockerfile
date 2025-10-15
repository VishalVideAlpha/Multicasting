# Build stage
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src

# Copy all client files
COPY Client/ ./Client/
RUN dotnet restore Client/Client.csproj
RUN dotnet publish Client/Client.csproj -c Release -o /app/publish

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish ./

# Expose the port inside the container
EXPOSE 86

# Run the app
ENTRYPOINT ["dotnet", "Client.dll"]
