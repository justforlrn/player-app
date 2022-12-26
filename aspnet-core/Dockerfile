#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["NuGet.Config", "."]
COPY ["src/WebActiveHealthyKidsVietNam.HttpApi.Host/WebActiveHealthyKidsVietNam.HttpApi.Host.csproj", "src/WebActiveHealthyKidsVietNam.HttpApi.Host/"]
COPY ["src/WebActiveHealthyKidsVietNam.Application/WebActiveHealthyKidsVietNam.Application.csproj", "src/WebActiveHealthyKidsVietNam.Application/"]
COPY ["src/WebActiveHealthyKidsVietNam.Domain/WebActiveHealthyKidsVietNam.Domain.csproj", "src/WebActiveHealthyKidsVietNam.Domain/"]
COPY ["src/WebActiveHealthyKidsVietNam.Domain.Shared/WebActiveHealthyKidsVietNam.Domain.Shared.csproj", "src/WebActiveHealthyKidsVietNam.Domain.Shared/"]
COPY ["src/WebActiveHealthyKidsVietNam.Application.Contracts/WebActiveHealthyKidsVietNam.Application.Contracts.csproj", "src/WebActiveHealthyKidsVietNam.Application.Contracts/"]
COPY ["src/WebActiveHealthyKidsVietNam.EntityFrameworkCore/WebActiveHealthyKidsVietNam.EntityFrameworkCore.csproj", "src/WebActiveHealthyKidsVietNam.EntityFrameworkCore/"]
COPY ["src/WebActiveHealthyKidsVietNam.HttpApi/WebActiveHealthyKidsVietNam.HttpApi.csproj", "src/WebActiveHealthyKidsVietNam.HttpApi/"]
RUN dotnet restore "src/WebActiveHealthyKidsVietNam.HttpApi.Host/WebActiveHealthyKidsVietNam.HttpApi.Host.csproj"
COPY . .
WORKDIR "/src/src/WebActiveHealthyKidsVietNam.HttpApi.Host"
RUN dotnet build "WebActiveHealthyKidsVietNam.HttpApi.Host.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WebActiveHealthyKidsVietNam.HttpApi.Host.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WebActiveHealthyKidsVietNam.HttpApi.Host.dll"]