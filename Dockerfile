FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["api-pickupvb/api-pickupvb.csproj", "api-pickupvb/"]
COPY ["api-pickupvb.data/api-pickupvb.data.csproj", "api-pickupvb.data/"]
COPY ["api-pickupvb.model/api-pickupvb.model.csproj", "api-pickupvb.model/"]
COPY ["api-pickupvb.service/api-pickupvb.service.csproj", "api-pickupvb.service/"]
RUN dotnet restore "api-pickupvb/api-pickupvb.csproj"
COPY . .
WORKDIR "/src/api-pickupvb"
RUN dotnet build "api-pickupvb.csproj" -c Release -o /app/build
FROM build AS publish
RUN dotnet publish "api-pickupvb.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "api-pickupvb.dll"]