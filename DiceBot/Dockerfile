FROM mcr.microsoft.com/dotnet/runtime:10.0 AS base
USER $APP_UID
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["DiceBot/DiceBot.csproj", "DiceBot/"]
RUN dotnet restore "DiceBot/DiceBot.csproj"
COPY . .
WORKDIR "/src/DiceBot"
RUN dotnet build "./DiceBot.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DiceBot.dll"]
