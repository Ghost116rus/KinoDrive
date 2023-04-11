#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 40
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["MainAplication/Presentation/KinoDriveWebAPI/KinoDriveWebAPI.csproj", "MainAplication/Presentation/KinoDriveWebAPI/"]
COPY ["MainAplication/Core/KinoDrive.Aplication/KinoDrive.Aplication.csproj", "MainAplication/Core/KinoDrive.Aplication/"]
COPY ["MainAplication/Core/KinoDrive.Domain/KinoDrive.Domain.csproj", "MainAplication/Core/KinoDrive.Domain/"]
COPY ["MainAplication/Infrastructure/KinoDrive.Authentication/KinoDrive.Authentication.csproj", "MainAplication/Infrastructure/KinoDrive.Authentication/"]
COPY ["MainAplication/Infrastructure/KinoDrive.Persistance/KinoDrive.Persistance.csproj", "MainAplication/Infrastructure/KinoDrive.Persistance/"]
RUN dotnet restore "MainAplication/Presentation/KinoDriveWebAPI/KinoDriveWebAPI.csproj"
COPY . .
WORKDIR "/src/MainAplication/Presentation/KinoDriveWebAPI"
RUN dotnet build "KinoDriveWebAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "KinoDriveWebAPI.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "KinoDriveWebAPI.dll"]