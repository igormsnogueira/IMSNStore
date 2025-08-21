
FROM mcr.microsoft.com/dotnet/framework/sdk:4.8 AS build-env

WORKDIR /app

COPY *.sln ./
COPY IMSNStore.DataLayer/*.csproj ./IMSNStore.DataLayer/
COPY IMSNStore.ServiceLayer/*.csproj ./IMSNStore.ServiceLayer/
COPY IMSNStore.WebForms/*.csproj ./IMSNStore.WebForms/

RUN nuget restore IMSNStore.sln

COPY . .

RUN msbuild /p:Configuration=Release IMSNStore.sln

FROM mcr.microsoft.com/dotnet/framework/aspnet:4.8

COPY --from=build-env /app/IMSNStore.WebForms /inetpub/wwwroot/

EXPOSE 80