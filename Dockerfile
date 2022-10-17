FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 5001
EXPOSE 5002

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY . .
WORKDIR "/src/OrchardCoreHeadlessBackend"
RUN dotnet restore "OrchardCoreHeadlessBackend.csproj"
RUN dotnet build "OrchardCoreHeadlessBackend.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "OrchardCoreHeadlessBackend.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "OrchardCoreHeadlessBackend.dll"]