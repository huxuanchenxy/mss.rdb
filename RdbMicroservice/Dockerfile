FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY rdbMicroservice.csproj rdbMicroservice/
RUN dotnet restore rdbMicroservice/rdbMicroservice.csproj
WORKDIR /src/rdbMicroservice
COPY . .
RUN dotnet build rdbMicroservice.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish rdbMicroservice.csproj -c Release -o /app

FROM base AS final
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "rdbMicroservice.dll"]