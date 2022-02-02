FROM image-registry.openshift-image-registry.svc:5000/e704e1-tools/dotnet-50
USER 1001
RUN mkdir Gov.News.Search.Reset.Service
WORKDIR Gov.News.Search.Reset.Service
ADD . .

RUN dotnet publish -c Release

EXPOSE 80
EXPOSE 443

CMD ["dotnet", "./bin/Release/net5.0/publish/Gov.News.Search.Reset.Service.dll"]
