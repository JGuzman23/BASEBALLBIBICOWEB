FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /app

#COPY PROJECT FILES
COPY *.csproj ./
RUN dotnet restore

#COPY EVERYTHING ELSE
COPY . ./
RUN dotnet publish -c Release -o out

#BUILD IMAGE
FROM mcr.microsoft.com/dotnet/sdk:5.0
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT ["dotnet","BASEBALLBIBICOWEB.dll"]

