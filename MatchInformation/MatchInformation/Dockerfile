#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["MatchInformation/MatchInformation.csproj", "MatchInformation/"]
RUN dotnet restore "MatchInformation/MatchInformation.csproj"
COPY . .
WORKDIR "/src/MatchInformation"
RUN dotnet build "MatchInformation.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MatchInformation.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MatchInformation.dll"]