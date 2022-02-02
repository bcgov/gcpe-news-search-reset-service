FROM registry.access.redhat.com/ubi8/dotnet-50-runtime:5.0-30.20220127181329
USER 1001
RUN mkdir Gov.News.Search.Reset.Service
WORKDIR Gov.News.Search.Reset.Service
ADD . .

RUN dotnet publish -c Release

EXPOSE 80
EXPOSE 443

CMD ["dotnet", "./bin/Release/net5.0/publish/Gov.News.Search.Reset.Service.dll"]