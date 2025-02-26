FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 5079

ENV ASPNETCORE_URLS=http://+:5079
ENV DOTNET_NOLOGO=true
ENV DOTNET_CLI_TELEMETRY_OPTOUT=true

RUN adduser -u 5678 --disabled-password --gecos "" appuser && chown -R appuser /app
USER appuser

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /backend/poc.cqrs.api.twilio.net8/src/01-Presentation

# Copia o arquivo .csproj para o diretório de trabalho atual no contêiner
COPY backend/poc.cqrs.api.twilio.net8/src/01-Presentation/Poc.Twilio.API/Poc.Twilio.API.csproj .
COPY backend/poc.cqrs.api.twilio.net8/src/02-Application/Poc.Command/Poc.Command.csproj .
COPY backend/poc.cqrs.api.twilio.net8/src/02-Application/Poc.Query/Poc.Query.csproj .
COPY backend/poc.cqrs.api.twilio.net8/src/02-Application/Poc.Contract/Poc.Contract.csproj .
COPY backend/poc.cqrs.api.twilio.net8/src/04-Infrastructure/DistributedCache/Poc.DistributedCache/Poc.DistributedCache.csproj .
COPY backend/poc.cqrs.api.twilio.net8/src/04-Infrastructure/Integration/Poc.Auth/Poc.Auth.csproj .

# Restaura as dependências do projeto
RUN dotnet restore Poc.Twilio.API.csproj

# Copia o restante dos arquivos do projeto para o contêiner
COPY . .

# Define o diretório de trabalho e constrói o projeto
WORKDIR /backend/poc.cqrs.api.twilio.net8/src/01-Presentation
RUN dotnet build backend/poc.cqrs.api.twilio.net8/src/01-Presentation/Poc.Twilio.API/Poc.Twilio.API.csproj -c Release -o /app/build

FROM build AS publish
RUN dotnet publish backend/poc.cqrs.api.twilio.net8/src/01-Presentation/Poc.Twilio.API/Poc.Twilio.API.csproj -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Poc.Twilio.API.dll"]