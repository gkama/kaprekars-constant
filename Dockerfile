FROM mcr.microsoft.com/dotnet/aspnet:6.0-alpine
WORKDIR /app
EXPOSE 80

COPY /app/publish/kaprekars.constant.core /app/
ENTRYPOINT ["dotnet", "kaprekars.constant.core.dll"]