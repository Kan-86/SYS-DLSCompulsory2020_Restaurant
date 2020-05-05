#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Epic_Retaurant_FoodOrders/Epic_Retaurant_Food_Menus.csproj", "Epic_Retaurant_FoodOrders/"]
COPY ["SharedModels/SharedModels.csproj", "SharedModels/"]
RUN dotnet restore "Epic_Retaurant_FoodOrders/Epic_Retaurant_Food_Menus.csproj"
COPY . .
WORKDIR "/src/Epic_Retaurant_FoodOrders"
RUN dotnet build "Epic_Retaurant_Food_Menus.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Epic_Retaurant_Food_Menus.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Epic_Retaurant_Food_Menus.dll"]