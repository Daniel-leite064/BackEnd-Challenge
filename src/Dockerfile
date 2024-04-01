FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["${PWD}/src/BackEnd.Api/.", "BackEnd.Api/"]
COPY ["${PWD}/src/BackEnd.Domain/.", "BackEnd.Domain/"]
COPY ["${PWD}/src/BackEnd.Infra/.", "BackEnd.Infra/"]
RUN dotnet restore "BackEnd.Api/BackEnd.Api.csproj"
COPY . .
WORKDIR "/src/BackEnd.Api"
RUN dotnet build "BackEnd.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BackEnd.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BackEnd.Api.dll"]
