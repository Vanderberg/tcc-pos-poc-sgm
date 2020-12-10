#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["SGM.Cidadao/SGM.Cidadao.Application/SGM.Cidadao.Application.csproj", "SGM.Cidadao/SGM.Cidadao.Application/"]
COPY ["SGM.Cidadao/SGM.Cidadao.CrossCutting/SGM.Cidadao.CrossCutting.csproj", "SGM.Cidadao/SGM.Cidadao.CrossCutting/"]
COPY ["SGM.Cidadao/SGM.Cidadao.Service/SGM.Cidadao.Service.csproj", "SGM.Cidadao/SGM.Cidadao.Service/"]
COPY ["SGM.Cidadao/SGM.Cidadao.Data/SGM.Cidadao.Data.csproj", "SGM.Cidadao/SGM.Cidadao.Data/"]
COPY ["SGM.Cidadao/SGM.Cidadao.Domain/SGM.Cidadao.Domain.csproj", "SGM.Cidadao/SGM.Cidadao.Domain/"]
RUN dotnet restore "SGM.Cidadao/SGM.Cidadao.Application/SGM.Cidadao.Application.csproj"
COPY . .
WORKDIR "/src/SGM.Cidadao/SGM.Cidadao.Application"
RUN dotnet build "SGM.Cidadao.Application.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SGM.Cidadao.Application.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SGM.Cidadao.Application.dll"]