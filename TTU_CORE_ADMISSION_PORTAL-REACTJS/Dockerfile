FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

# Install Node.js
RUN curl -fsSL https://deb.nodesource.com/setup_14.x | bash - \
    && apt-get install -y \
        nodejs \
    && rm -rf /var/lib/apt/lists/*

WORKDIR /src
COPY ["TTU_CORE_ADMISSION_PORTAL-REACTJS/TTU_CORE_ADMISSION_PORTAL-REACTJS.csproj", "TTU_CORE_ADMISSION_PORTAL-REACTJS/"]
RUN dotnet restore "TTU_CORE_ADMISSION_PORTAL-REACTJS/TTU_CORE_ADMISSION_PORTAL-REACTJS.csproj"
COPY . .
WORKDIR "/src/TTU_CORE_ADMISSION_PORTAL-REACTJS"
RUN dotnet build "TTU_CORE_ADMISSION_PORTAL-REACTJS.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TTU_CORE_ADMISSION_PORTAL-REACTJS.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TTU_CORE_ADMISSION_PORTAL-REACTJS.dll"]
