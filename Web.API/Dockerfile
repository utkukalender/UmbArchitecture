#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src

COPY ["Core/Core.csproj", "Web.API/"]
COPY ["Umb.Applicaton/Umb.Applicaton.csproj", "Umb.Applicaton/"]
COPY ["Umb.Domain/Umb.Domain.csproj", "Umb.Domain/"]
COPY ["Umb.Persistance/Umb.Persistance.csproj", "Umb.Persistance/"]
COPY ["Umb.Infasructure/Umb.Infasructure.csproj", "Umb.Infasructure/"]

RUN dotnet restore "Web.API/Web.API.csproj"
COPY . .
WORKDIR "/src/Web.API"
RUN dotnet build "Web.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Web.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Web.API.dll"]