# Build stage
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src

# Copy only the project file first (for caching)
COPY Client.csproj ./
RUN dotnet restore Client.csproj

# Copy the rest of the source code
COPY . ./

# Publish
RUN dotnet publish Client.csproj -c Release -o /app/publish

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime
WORKDIR /app

# Copy published files
COPY --from=build /app/publish ./

# Expose port
EXPOSE 86

# Run the app
ENTRYPOINT ["dotnet", "Client.dll"]

