#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Finance.csproj", "Finance/"]
RUN dotnet restore "Finance/Finance.csproj"
COPY . .
WORKDIR "/src/Finance"
RUN dotnet build "Finance.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Finance.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Finance.dll"]