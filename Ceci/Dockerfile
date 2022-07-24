#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Ceci.WebApplication/Ceci.WebApplication.csproj", "Ceci.WebApplication/"]
COPY ["Ceci.Service/Ceci.Service.csproj", "Ceci.Service/"]
COPY ["Ceci.Infra.Data/Ceci.Infra.Data.csproj", "Ceci.Infra.Data/"]
COPY ["Ceci.Infra.CrossCutting/Ceci.Infra.CrossCutting.csproj", "Ceci.Infra.CrossCutting/"]
COPY ["Ceci.Domain/Ceci.Domain.csproj", "Ceci.Domain/"]
COPY ["Ceci.WebApplication/Ceci.Domain.xml", "Ceci.WebApplication/"]
COPY ["Ceci.WebApplication/Ceci.WebApplication.xml", "Ceci.WebApplication/"]
RUN dotnet restore "Ceci.WebApplication/Ceci.WebApplication.csproj"
COPY . .
WORKDIR "/src/Ceci.WebApplication"
RUN dotnet build "Ceci.WebApplication.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Ceci.WebApplication.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Ceci.WebApplication.dll"]