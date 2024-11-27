# Pou��vame ofici�lny .NET SDK image na build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Kop�rovanie csproj a obnovenie z�vislost�
COPY . ./
RUN dotnet restore

# Kop�rovanie v�etk�ch s�borov a build aplik�cie
#COPY . ./
RUN dotnet publish -c Release -o /app/publish

# Fin�lny image s runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .

# Otv�rame port 80 pre HTTP a 443 pre HTTPS
# EXPOSE 80
# EXPOSE 443

ENTRYPOINT ["dotnet", "Eshop.WebApi.dll"]
