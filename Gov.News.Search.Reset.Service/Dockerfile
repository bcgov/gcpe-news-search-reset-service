FROM image-registry.apps.silver.devops.gov.bc.ca/e704e1-tools/dotnet-50:5.0-30.20220127181929
USER 1001
RUN mkdir Gov.News.Search.Reset.Service
WORKDIR Gov.News.Search.Reset.Service
ADD . .

RUN dotnet publish -c Release

EXPOSE 80
EXPOSE 443

CMD ["dotnet", "./bin/Release/net5.0/publish/Gov.News.Search.Reset.Service.dll"]
