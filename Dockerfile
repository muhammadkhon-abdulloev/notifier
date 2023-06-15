FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR .

COPY ./*.csproj ./
RUN dotnet restore

COPY . ./notifier/
WORKDIR ./notifier
RUN dotnet publish -c release -o /app

FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app
COPY --from=build /app ./
ENTRYPOINT ["dotnet", "NotifierApp.dll"]