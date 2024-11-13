#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/CarePaws.API/CarePaws.API.csproj", "src/CarePaws.API/"]
COPY ["src/CarePaws.Domain/CarePaws.Domain.csproj", "src/CarePaws.Domain/"]
COPY ["src/CarePaws.Infrastructure/CarePaws.Infrastructure.csproj", "src/CarePaws.Infrastructure/"]
COPY ["src/CarePaws.Application/CarePaws.Application.csproj", "src/CarePaws.Application/"]
RUN dotnet restore "./src/CarePaws.API/./CarePaws.API.csproj"
COPY . .
WORKDIR "/src/src/CarePaws.API"
RUN dotnet build "./CarePaws.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./CarePaws.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CarePaws.API.dll"]