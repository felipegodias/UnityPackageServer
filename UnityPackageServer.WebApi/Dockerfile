FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["UnityPackageServer.WebApi/UnityPackageServer.WebApi.csproj", "UnityPackageServer.WebApi/"]
RUN dotnet restore "UnityPackageServer.WebApi/UnityPackageServer.WebApi.csproj"
COPY . .
WORKDIR "/src/UnityPackageServer.WebApi"
RUN dotnet build "UnityPackageServer.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "UnityPackageServer.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NPM.dll"]
