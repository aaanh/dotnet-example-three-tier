# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy solution and restore
COPY *.sln .
COPY example-three-tier.Data/*.csproj example-three-tier.Data/
COPY example-three-tier.Business/*.csproj example-three-tier.Business/
COPY example-three-tier.Web/*.csproj example-three-tier.Web/
RUN dotnet restore

# Copy everything else and build
COPY . .
WORKDIR /src/example-three-tier.Web
RUN dotnet publish -c Release -o /app

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app .
ENTRYPOINT ["dotnet", "example-three-tier.Web.dll"]
