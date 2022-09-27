FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

# Install Node.js
RUN curl -fsSL https://deb.nodesource.com/setup_14.x | bash - \
    && apt-get install -y \
        nodejs \
    && rm -rf /var/lib/apt/lists/*

WORKDIR /src
COPY ["UnityPackageServer.Frontend/UnityPackageServer.Frontend.csproj", "UnityPackageServer.Frontend/"]
RUN dotnet restore "UnityPackageServer.Frontend/UnityPackageServer.Frontend.csproj"
COPY . .
WORKDIR "/src/UnityPackageServer.Frontend"
RUN dotnet build "UnityPackageServer.Frontend.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "UnityPackageServer.Frontend.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "UnityPackageServer.Frontend.dll"]
