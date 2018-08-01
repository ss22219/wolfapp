FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY Wolf.Core.Web/Wolf.Core.Web.csproj Wolf.Core.Web/
RUN dotnet restore Wolf.Core.Web/Wolf.Core.Web.csproj
COPY . .
WORKDIR /src/Wolf.Core.Web
RUN dotnet build Wolf.Core.Web.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish Wolf.Core.Web.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .

ENTRYPOINT ["dotnet", "Wolf.Core.Web.dll"]
