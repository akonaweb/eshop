# Používame oficiálny .NET SDK image na build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Kopírovanie csproj a obnovenie závislostí
COPY . ./
RUN dotnet restore

# Kopírovanie všetkých súborov a build aplikácie
#COPY . ./
RUN dotnet publish -c Release -o /app/publish

# Finálny image s runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .

# Otvárame port 80 pre HTTP a 443 pre HTTPS
# EXPOSE 80
# EXPOSE 443

ENTRYPOINT ["dotnet", "Eshop.WebApi.dll"]
