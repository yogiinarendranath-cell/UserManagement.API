# Build Stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy csproj and restore dependencies
COPY ["UserManagement.API/UserManagement.API.csproj", "UserManagement.API/"]
RUN dotnet restore "UserManagement.API/UserManagement.API.csproj"

# Copy everything else and build
COPY . .
WORKDIR "/src/UserManagement.API"
RUN dotnet build "UserManagement.API.csproj" -c Release -o /app/build

# Publish Stage
FROM build AS publish
RUN dotnet publish "UserManagement.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Runtime Stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
EXPOSE 80
EXPOSE 443

# Copy published files
COPY --from=publish /app/publish .

# Set entry point
ENTRYPOINT ["dotnet", "UserManagement.API.dll"]
