# Use official .NET SDK image to build the app
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

WORKDIR /src

# Copy csproj and restore dependencies
COPY Client/Client.csproj ./Client/
RUN dotnet restore ./Client/Client.csproj

# Copy the rest of the source code
COPY Client/ ./Client/

# Publish the app
RUN dotnet publish ./Client/Client.csproj -c Release -o /app/publish

# Runtime image
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish ./

# Expose container port 5000
EXPOSE 5000

# Run the app
ENTRYPOINT ["dotnet", "Client.dll"]
