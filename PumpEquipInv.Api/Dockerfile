FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 5000


FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY PumpEquipInv.Api/PumpEquipInv.Api.csproj PumpEquipInv.Api/
COPY PumpEquipInv.DataAccess/PumpEquipInv.DataAccess.csproj PumpEquipInv.DataAccess/
COPY PumpEquipInv.Core/PumpEquipInv.Core.csproj PumpEquipInv.Core/
RUN dotnet restore "PumpEquipInv.Api/PumpEquipInv.Api.csproj"
COPY . .
WORKDIR "/src/PumpEquipInv.Api"
RUN dotnet build "PumpEquipInv.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "PumpEquipInv.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PumpEquipInv.Api.dll"]
