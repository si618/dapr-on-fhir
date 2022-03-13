#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["NuGet.config", "."]
COPY ["services/Lab/LabService.Api/LabService.Api.csproj", "services/Lab/LabService.Api/"]
RUN dotnet restore "services/Lab/LabService.Api/LabService.Api.csproj"
COPY . .
WORKDIR "/src/services/Lab/LabService.Api"
RUN dotnet build "LabService.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "LabService.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LabService.Api.dll"]
