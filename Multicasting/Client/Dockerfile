# Build stage
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src

# Copy csproj and restore dependencies
COPY Client.csproj ./
RUN dotnet restore Client.csproj

# Copy remaining source code
COPY . ./
RUN dotnet publish Client.csproj -c Release -o /app/publish

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish ./

EXPOSE 86
ENTRYPOINT ["dotnet", "Client.dll"]
