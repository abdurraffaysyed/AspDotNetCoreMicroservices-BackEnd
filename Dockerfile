FROM mcr.microsoft.com/dotnet/core/aspnet:2.1-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.1-stretch AS build
WORKDIR /src
COPY ["ProductsMicroservice.csproj", ""]
RUN dotnet restore "./ProductsMicroservice.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "ProductsMicroservice.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "ProductsMicroservice.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "ProductsMicroservice.dll"]