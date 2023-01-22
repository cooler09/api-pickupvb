FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["api-pickupvb.csproj", "./"]
RUN dotnet restore "./api-pickupvb.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "api-pickupvb.csproj" -c Release -o /app/build
FROM build AS publish
RUN dotnet publish "api-pickupvb.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "api-pickupvb.dll"]