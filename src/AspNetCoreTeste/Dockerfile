FROM microsoft/dotnet:1.1.0-sdk-projectjson
WORKDIR /app
ENV ASPNETCORE_URLS http://*:5001
EXPOSE 5001
ENTRYPOINT ["dotnet", "AspNetCoreTeste.dll"]
COPY . /app
