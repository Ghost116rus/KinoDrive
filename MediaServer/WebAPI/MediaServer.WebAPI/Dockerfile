#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 40
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["MediaServer/WebAPI/MediaServer.WebAPI/MediaServer.WebAPI.csproj", "MediaServer/WebAPI/MediaServer.WebAPI/"]
COPY ["MediaServer/Core/MediaCore/MediaCore.csproj", "MediaServer/Core/MediaCore/"]
COPY ["MediaServer/Infrastructure/MediaServer.DAL/MediaServer.DAL.csproj", "MediaServer/Infrastructure/MediaServer.DAL/"]
RUN dotnet restore "MediaServer/WebAPI/MediaServer.WebAPI/MediaServer.WebAPI.csproj"
COPY . .
WORKDIR "/src/MediaServer/WebAPI/MediaServer.WebAPI"
RUN dotnet build "MediaServer.WebAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MediaServer.WebAPI.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
COPY ["MediaServer/media", "/media"]
ENTRYPOINT ["dotnet", "MediaServer.WebAPI.dll"]