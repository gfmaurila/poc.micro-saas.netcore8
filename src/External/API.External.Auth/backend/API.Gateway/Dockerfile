# Use a base image for ASP.NET Core
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 5060

ENV ASPNETCORE_URLS=http://+:5060
ENV DOTNET_NOLOGO=true
ENV DOTNET_CLI_TELEMETRY_OPTOUT=true

RUN adduser -u 5678 --disabled-password --gecos "" appuser && chown -R appuser /app
USER appuser

# Use the .NET SDK image for building the application
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /backend

# Copy the project file and restore dependencies
COPY backend/API.Gateway/API.Gateway.csproj .
RUN dotnet restore API.Gateway.csproj

# Copy the rest of the application and build it
COPY . .
WORKDIR /backend
RUN dotnet build backend/API.Gateway/API.Gateway.csproj -c Release -o /app/build

# Publish the application
FROM build AS publish
RUN dotnet publish backend/API.Gateway/API.Gateway.csproj -c Release -o /app/publish

# Use the base image to run the application
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "API.Gateway.dll"] # Certifique-se de que este nome corresponda ao nome correto da DLL gerada