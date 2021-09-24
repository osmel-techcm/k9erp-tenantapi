#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
RUN apt-get update && apt-get install -y apt-utils libgdiplus libc6-dev
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["tenantApi/tenantApi.csproj", "tenantApi/"]
COPY ["tenantCore/tenantCore.csproj", "tenantCore/"]
COPY ["tenantShared/tenantShared.csproj", "tenantShared/"]
COPY ["tenantInfrastructure/tenantInfrastructure.csproj", "tenantInfrastructure/"]
RUN dotnet restore "tenantApi/tenantApi.csproj"
COPY . .
WORKDIR "/src/tenantApi"
RUN dotnet build "tenantApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "tenantApi.csproj" -c Release -o /app/publish

FROM base AS final

# Install Microsoft core fonts
RUN echo "deb http://deb.debian.org/debian stable main contrib non-free" > /etc/apt/sources.list \
    && echo "ttf-mscorefonts-installer msttcorefonts/accepted-mscorefonts-eula select true" | debconf-set-selections \
    && apt-get update \
    && apt-get install -y \
        ttf-mscorefonts-installer \
    && apt-get clean \
    && apt-get autoremove -y \
    && rm -rf /var/lib/apt/lists/*
    
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "tenantApi.dll"]