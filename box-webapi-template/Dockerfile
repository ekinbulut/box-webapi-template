FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["box-webapi-template/box-webapi-template.csproj", "box-webapi-template/"]
RUN dotnet restore "box-webapi-template/box-webapi-template.csproj"
COPY . .
WORKDIR "/src/box-webapi-template"
RUN dotnet build "box-webapi-template.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "box-webapi-template.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "box-webapi-template.dll"]
