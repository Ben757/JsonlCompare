FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Server/JsonlCompare.Server.csproj", "Server/"]
COPY ["Client/JsonlCompare.Client.csproj", "Client/"]
COPY ["Shared/JsonlCompare.Shared.csproj", "Shared/"]
RUN dotnet restore "Server/JsonlCompare.Server.csproj"
COPY . .
WORKDIR "/src/Server"
RUN dotnet build "JsonlCompare.Server.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "JsonlCompare.Server.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "JsonlCompare.Server.dll"]
