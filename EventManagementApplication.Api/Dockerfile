FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["EventManagementApplication.Api/EventManagementApplication.Api.csproj", "EventManagementApplication.Api/"]
COPY ["EventManagementApplication.Business/EventManagementApplication.Business.csproj", "EventManagementApplication.Business/"]
COPY ["EventManagementApplication.Core/EventManagementApplication.Core.csproj", "EventManagementApplication.Core/"]
COPY ["EventManagementApplication.Entities/EventManagementApplication.Entities.csproj", "EventManagementApplication.Entities/"]
COPY ["EventManagementApplication.DataAccess/EventManagementApplication.DataAccess.csproj", "EventManagementApplication.DataAccess/"]
RUN dotnet restore "EventManagementApplication.Api/EventManagementApplication.Api.csproj"
COPY . .
WORKDIR "/src/EventManagementApplication.Api"
RUN dotnet build "EventManagementApplication.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "EventManagementApplication.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EventManagementApplication.Api.dll"]
