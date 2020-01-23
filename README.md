# Инструкция по запуску
Для запуска приложения необходимы nodejs и dotnet.

Запуск приложения можно осуществить выполнением launch-me.bat. Что происходит в этом случае:
- устанавливаются npm-пакеты (npm install)
- с помощью Webpack собирается бандл в production-режиме (webpack --mode production)
- собирается и запускается приложение (dotnet run -c Release --environment="Production")  
  
При желании, команды можно выполнить вручную. Для этого необходимо перейти в директорию src/JustAnotherSimpleFormApplication.Web и выполнить команды:  
для Release:  
npm install  
npm run build:prod  
dotnet run -c Release --environment="Production"  
  
для Dev:  
npm install  
npm run build:dev  
dotnet run  
