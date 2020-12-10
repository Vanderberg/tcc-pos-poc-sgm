#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["SGM.Gestao/SGM.Gestao.Application/SGM.Gestao.Application.csproj", "SGM.Gestao/SGM.Gestao.Application/"]
COPY ["SGM.Gestao/SGM.Gestao.CrossCutting/SGM.Gestao.CrossCutting.csproj", "SGM.Gestao/SGM.Gestao.CrossCutting/"]
COPY ["SGM.Gestao/SGM.Gestao.Service/SGM.Gestao.Service.csproj", "SGM.Gestao/SGM.Gestao.Service/"]
COPY ["SGM.Gestao/SGM.Gestao.Data/SGM.Gestao.Data.csproj", "SGM.Gestao/SGM.Gestao.Data/"]
COPY ["SGM.Gestao/SGM.Gestao.Domain/SGM.Gestao.Domain.csproj", "SGM.Gestao/SGM.Gestao.Domain/"]
RUN dotnet restore "SGM.Gestao/SGM.Gestao.Application/SGM.Gestao.Application.csproj"
COPY . .
WORKDIR "/src/SGM.Gestao/SGM.Gestao.Application"
RUN dotnet build "SGM.Gestao.Application.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SGM.Gestao.Application.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SGM.Gestao.Application.dll"]