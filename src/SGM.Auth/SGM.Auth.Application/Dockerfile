#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["SGM.Auth/SGM.Auth.Application/SGM.Auth.Application.csproj", "SGM.Auth/SGM.Auth.Application/"]
COPY ["SGM.Auth/SGM.Auth.Service/SGM.Auth.Service.csproj", "SGM.Auth/SGM.Auth.Service/"]
COPY ["SGM.Auth/SGM.Auth.Data/SGM.Auth.Data.csproj", "SGM.Auth/SGM.Auth.Data/"]
COPY ["SGM.Auth/SGM.Auth.Domain/SGM.Auth.Domain.csproj", "SGM.Auth/SGM.Auth.Domain/"]
COPY ["SGM.Auth/SGM.Auth.CrossCutting/SGM.Auth.CrossCutting.csproj", "SGM.Auth/SGM.Auth.CrossCutting/"]
RUN dotnet restore "SGM.Auth/SGM.Auth.Application/SGM.Auth.Application.csproj"
COPY . .
WORKDIR "/src/SGM.Auth/SGM.Auth.Application"
RUN dotnet build "SGM.Auth.Application.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SGM.Auth.Application.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SGM.Auth.Application.dll"]