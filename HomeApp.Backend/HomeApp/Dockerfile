#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["HomeApp/HomeApp.csproj", "HomeApp/"]
COPY ["HomeApp.ApiCore/HomeApp.ApiCore.csproj", "HomeApp.ApiCore/"]
RUN dotnet restore "HomeApp/HomeApp.csproj"
COPY . .
WORKDIR "/src/HomeApp"
RUN dotnet build "HomeApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "HomeApp.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HomeApp.dll"]