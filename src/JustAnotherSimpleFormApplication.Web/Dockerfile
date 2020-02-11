FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
RUN apt-get update -y && apt-get install -y gnupg2 && curl -sL https://deb.nodesource.com/setup_10.x | bash - && apt-get update -y && apt-get install -y nodejs
WORKDIR /app/src
COPY . .
WORKDIR /app/src/JustAnotherSimpleFormApplication.Web
RUN npm run build:prod

FROM build AS publish
RUN dotnet publish "JustAnotherSimpleFormApplication.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish .app/publish .
ENTRYPOINT ["dotnet", "JustAnotherSimpleFormApplication.Web.dll"]