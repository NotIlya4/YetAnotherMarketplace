FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

# Restore
RUN dotnet tool install --global dotnet-ef
WORKDIR /src
COPY Api/Api.csproj Api/
COPY Infrastructure/Infrastructure.csproj Infrastructure/
COPY Domain/Domain.csproj Domain/
WORKDIR /src/Api
RUN dotnet restore -r linux-x64

# Copy rest files
WORKDIR /src
COPY . .

# Create migration bundle
WORKDIR /src/Api
ENV PATH="${PATH}:/root/.dotnet/tools"
RUN dotnet ef migrations bundle --verbose -o /src/migrations-bundle

# Build
WORKDIR /src/Api
RUN dotnet build "Api.csproj" -c Release -o /app/build
RUN dotnet publish "Api.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS final
EXPOSE 80
WORKDIR /app
COPY --from=build /app/publish .
COPY --from=build /src/migrations-bundle .
ENTRYPOINT ["dotnet", "Api.dll"]