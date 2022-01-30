#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["Ecommerce_Backend/Ecommerce_Backend.csproj", "Ecommerce_Backend/"]
RUN dotnet restore "Ecommerce_Backend/Ecommerce_Backend.csproj"
COPY . .
WORKDIR "/src/Ecommerce_Backend"
RUN dotnet build "Ecommerce_Backend.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Ecommerce_Backend.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Ecommerce_Backend.dll"]