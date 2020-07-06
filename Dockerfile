FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["phonebookCollectionService.csproj", ""]
RUN dotnet restore "./phonebookCollectionService.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "phonebookCollectionService.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "phonebookCollectionService.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "phonebookCollectionService.dll"]

#SQL
ENV sql__ReadConnectionString="Server=tcp:pafelaserver.database.windows.net,1433;Initial Catalog=PafelaDB;Persist Security Info=False;User ID=Katlego;Password=123*()ZXC<>?qwe;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;" \
sql__WriteConnectionString="Server=tcp:pafelaserver.database.windows.net,1433;Initial Catalog=PafelaDB;Persist Security Info=False;User ID=Katlego;Password=123*()ZXC<>?qwe;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"