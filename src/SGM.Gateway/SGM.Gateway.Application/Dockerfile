#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["SGM.Gateway/SGM.Gateway.Application/SGM.Gateway.Application.csproj", "SGM.Gateway/SGM.Gateway.Application/"]

RUN dotnet restore "SGM.Gateway/SGM.Gateway.Application/SGM.Gateway.Application.csproj"
COPY . .
WORKDIR "/src/SGM.Gateway/SGM.Gateway.Application"
RUN dotnet build "SGM.Gateway.Application.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SGM.Gateway.Application.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SGM.Gateway.Application.dll"]