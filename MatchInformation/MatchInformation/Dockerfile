#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 5001

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["MatchInformation/MatchInformation.csproj", "MatchInformation/"]
COPY ["MatchInformation.Persistence/MatchInformation.Persistence.csproj", "MatchInformation.Persistence/"]
COPY ["MatchInformation.Application/MatchInformation.Application.csproj", "MatchInformation.Application/"]
COPY ["MatchInformation.Domain/MatchInformation.Domain.csproj", "MatchInformation.Domain/"]
RUN dotnet restore "MatchInformation/MatchInformation.csproj"
COPY . .
WORKDIR "/src/MatchInformation"
RUN dotnet build "MatchInformation.csproj" -c Debug -o /app/build

FROM build AS publish
RUN dotnet publish "MatchInformation.csproj" -c Debug -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MatchInformation.dll"]