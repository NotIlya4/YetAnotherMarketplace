FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY Api/Api.csproj Api/
COPY Infrastructure/Infrastructure.csproj Infrastructure/
COPY Domain/Domain.csproj Domain/
WORKDIR /src/Api
RUN dotnet restore
WORKDIR /src
COPY . .
WORKDIR /src/Api
RUN dotnet build "Api.csproj" -c Release -o /app/build
RUN dotnet publish "Api.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS final
EXPOSE 80
WORKDIR /app
ENV ConnectionStringName docker-compose
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "Api.dll"]