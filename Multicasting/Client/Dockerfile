# Build stage
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src

COPY . ./
RUN dotnet restore Client.csproj
RUN dotnet publish Client.csproj -c Release -o /app/publish

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish ./

EXPOSE 86
ENTRYPOINT ["dotnet", "Client.dll"]
