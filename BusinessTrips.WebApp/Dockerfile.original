FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["BusinessTrips.WebApp/BusinessTrips.WebApp.csproj", "BusinessTrips.WebApp/"]
RUN dotnet restore "BusinessTrips.WebApp/BusinessTrips.WebApp.csproj"
COPY . .
WORKDIR "/src/BusinessTrips.WebApp"
RUN dotnet build "BusinessTrips.WebApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BusinessTrips.WebApp.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BusinessTrips.WebApp.dll"]