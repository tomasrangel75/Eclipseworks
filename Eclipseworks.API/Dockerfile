#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Eclipseworks.API/Eclipseworks.API.csproj", "Eclipseworks.API/"]
COPY ["Eclipseworks.Application/Eclipseworks.Application.csproj", "Eclipseworks.Application/"]
COPY ["Eclipseworks.Domain/Eclipseworks.Domain.csproj", "Eclipseworks.Domain/"]
COPY ["Eclipseworks.Shared/Eclipseworks.Shared.csproj", "Eclipseworks.Shared/"]
COPY ["Eclipseworks.Infrastructure/Eclipseworks.Infrastructure.csproj", "Eclipseworks.Infrastructure/"]
COPY ["Eclipseworks.Persistence/Eclipseworks.Persistence.csproj", "Eclipseworks.Persistence/"]
RUN dotnet restore "Eclipseworks.API/Eclipseworks.API.csproj"
COPY . .
WORKDIR "/src/Eclipseworks.API"
RUN dotnet build "Eclipseworks.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Eclipseworks.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Eclipseworks.API.dll"]