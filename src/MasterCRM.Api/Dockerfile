FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["src/MasterCRM.Api/MasterCRM.Api.csproj", "src/MasterCRM.Api/"]
RUN dotnet restore "src/MasterCRM.Api/MasterCRM.Api.csproj"
COPY . .
WORKDIR "/src/src/MasterCRM.Api"
RUN dotnet build "MasterCRM.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MasterCRM.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MasterCRM.Api.dll"]
