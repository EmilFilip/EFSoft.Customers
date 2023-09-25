#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0.11-alpine3.18-amd64 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0.11-alpine3.18-amd64 AS build
WORKDIR /src
COPY ["NuGet.Config", "."]
COPY ["EFSoft.Customers.Api/EFSoft.Customers.Api.csproj", "EFSoft.Customers.Api/"]
COPY ["EFSoft.Customers.Application/EFSoft.Customers.Application.csproj", "EFSoft.Customers.Application/"]
COPY ["EFSoft.Customers.Domain/EFSoft.Customers.Domain.csproj", "EFSoft.Customers.Domain/"]
COPY ["EFSoft.Customers.Infrastructure/EFSoft.Customers.Infrastructure.csproj", "EFSoft.Customers.Infrastructure/"]
RUN dotnet restore "EFSoft.Customers.Api/EFSoft.Customers.Api.csproj"
COPY . .
WORKDIR "/src/EFSoft.Customers.Api"
RUN dotnet build "EFSoft.Customers.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "EFSoft.Customers.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EFSoft.Customers.Api.dll"]
