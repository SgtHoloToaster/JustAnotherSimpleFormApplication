FROM mcr.microsoft.com/dotnet/core/aspnet:2.2

WORKDIR /app
COPY publish .
EXPOSE 80

ENTRYPOINT ["dotnet", "JustAnotherSimpleFormApplication.Web.dll", "--urls", "http://0.0.0.0:80"]