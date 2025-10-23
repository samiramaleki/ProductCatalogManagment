#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["ProductCatalogManagment.Presentation/ProductCatalogManagment.Presentation.csproj", "ProductCatalogManagment.Presentation/"]
COPY ["ProductCatalogManagment.Application/ProductCatalogManagment.Application.csproj", "ProductCatalogManagment.Application/"]
COPY ["ProductCatalogManagment.Domain/ProductCatalogManagment.Domain.csproj", "ProductCatalogManagment.Domain/"]
COPY ["ProductCatalogManagment.Persistence/ProductCatalogManagment.Persistence.csproj", "ProductCatalogManagment.Persistence/"]
COPY ["ProductCatalogManagment.Infrastructure/ProductCatalogManagment.Infrastructure.csproj", "ProductCatalogManagment.Infrastructure/"]
RUN dotnet restore "./ProductCatalogManagment.Presentation/./ProductCatalogManagment.Presentation.csproj"
COPY . .
WORKDIR "/src/ProductCatalogManagment.Presentation"
RUN dotnet build "./ProductCatalogManagment.Presentation.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./ProductCatalogManagment.Presentation.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ProductCatalogManagment.Presentation.dll"]