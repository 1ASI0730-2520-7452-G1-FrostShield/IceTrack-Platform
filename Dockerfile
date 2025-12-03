FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app

ENV ASPNETCORE_URLS=http://0.0.0.0:${PORT}

EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

COPY ["IceTrackPlatform.API/IceTrackPlatform.API.csproj", "IceTrackPlatform.API/"]
RUN dotnet restore "IceTrackPlatform.API/IceTrackPlatform.API.csproj"

COPY . .
WORKDIR "/src/IceTrackPlatform.API"
RUN dotnet build "./IceTrackPlatform.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./IceTrackPlatform.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "IceTrackPlatform.API.dll"]
