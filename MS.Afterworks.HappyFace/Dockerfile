FROM microsoft/aspnetcore:2.0 AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/aspnetcore-build:2.0 AS build
WORKDIR /src
COPY MS.Afterworks.HappyFaceDemo.sln ./
COPY MS.Afterworks.HappyFace/MS.Afterworks.HappyFace.csproj MS.Afterworks.HappyFace/
COPY MS.Afterworks.HappyFace.Infrastructure/MS.Afterworks.HappyFace.Infrastructure.csproj MS.Afterworks.HappyFace.Infrastructure/
COPY MS.Afterworks.HappyFace.Core/MS.Afterworks.HappyFace.Core.csproj MS.Afterworks.HappyFace.Core/
RUN dotnet restore -nowarn:msb3202,nu1503
COPY . .
WORKDIR /src/MS.Afterworks.HappyFace
RUN dotnet build -c Release -o /app

FROM build AS publish
RUN dotnet publish -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "MS.Afterworks.HappyFace.dll"]
