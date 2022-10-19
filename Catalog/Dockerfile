#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS prepare-restore-files
ENV PATH="${PATH}:/root/.dotnet/tools"
# we use subnet tool for preparation when our project become complex
RUN dotnet tool install --global --no-cache dotnet-subset --version 0.3.0
WORKDIR /source
EXPOSE 80
EXPOSE 443
# this will copy all the files from current directory to another directory
#COPY . .
# copying csproj is better than copying all
COPY *.csproj Catalog/
#COPY . Catalog/
RUN dotnet subset restore Catalog/Catalog.csproj --root-directory /source --output restore_subset/

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /source
COPY --from=prepare-restore-files /source/restore_subset .
RUN dotnet restore Catalog/Catalog.csproj

# copy and build app and libraries
COPY . Catalog/
WORKDIR /source/Catalog
RUN dotnet build -c release --no-restore

FROM build AS publish
RUN dotnet publish -c release --no-build -o /app

# final stage/image
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=publish /app .

#If you’re using the Linux Container
HEALTHCHECK CMD curl --fail http://localhost || exit 1  
#If you’re using Windows Container with Powershell 
#HEALTHCHECK CMD powershell -command `  
#    try { `
#     $response = iwr http://localhost; `
#     if ($response.StatusCode -eq 200) { return 0} `
#     else {return 1}; `
#    } catch { return 1 }

ENTRYPOINT ["dotnet", "Catalog.dll"]