#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["NuGet.Config", "."]
COPY ["src/Player.HttpApi.Host/Player.HttpApi.Host.csproj", "src/Player.HttpApi.Host/"]
COPY ["src/Player.MongoDB/Player.MongoDB.csproj", "src/Player.MongoDB/"]
COPY ["src/Player.Domain/Player.Domain.csproj", "src/Player.Domain/"]
COPY ["src/Player.Domain.Shared/Player.Domain.Shared.csproj", "src/Player.Domain.Shared/"]
COPY ["src/Player.HttpApi/Player.HttpApi.csproj", "src/Player.HttpApi/"]
COPY ["src/Player.Application.Contracts/Player.Application.Contracts.csproj", "src/Player.Application.Contracts/"]
COPY ["src/Player.Application/Player.Application.csproj", "src/Player.Application/"]
RUN dotnet restore "src/Player.HttpApi.Host/Player.HttpApi.Host.csproj"
COPY . .
WORKDIR "/src/src/Player.HttpApi.Host"
RUN dotnet build "Player.HttpApi.Host.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Player.HttpApi.Host.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Player.HttpApi.Host.dll"]