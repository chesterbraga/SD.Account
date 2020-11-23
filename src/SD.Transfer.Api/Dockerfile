#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["src/SD.Transfer.Api/SD.Transfer.Api.csproj", "src/SD.Transfer.Api/"]
COPY ["src/SD.Transfer.Business/SD.Transfer.Business.csproj", "src/SD.Transfer.Business/"]
COPY ["src/SD.Transfer.Data/SD.Transfer.Data.csproj", "src/SD.Transfer.Data/"]
RUN dotnet restore "src/SD.Transfer.Api/SD.Transfer.Api.csproj"
COPY . .
WORKDIR "/src/src/SD.Transfer.Api"
RUN dotnet build "SD.Transfer.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SD.Transfer.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SD.Transfer.Api.dll"]
