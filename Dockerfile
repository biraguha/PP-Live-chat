FROM microsoft/dotnet:2.2-aspnetcore-runtime

WORKDIR /app

COPY ./publish .

# ENTRYPOINT ["dotnet", "livechat.dll"]

CMD ASPNETCORE_URLS=http://*:$PORT dotnet livechat.dll
