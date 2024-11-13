# 1. Aşama: Build aşaması
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY ["productapp.sln", "./"]
COPY ["src/API/API.csproj", "src/API/"]
COPY ["src/Application/Application.csproj", "src/Application/"]
COPY ["src/Domain/Domain.csproj", "src/Domain/"]
COPY ["src/Infrastructure/Infrastructure.csproj", "src/Infrastructure/"]

RUN dotnet restore

COPY . .

# WORKDIR "/src/API"
RUN dotnet publish "src/API/API.csproj" -c Release -o /out

# RUN dotnet publish "SikayetVar.API.csproj" -c Release -o /app/publish


FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app

COPY --from=build /out .

ENTRYPOINT ["dotnet", "API.dll"]
