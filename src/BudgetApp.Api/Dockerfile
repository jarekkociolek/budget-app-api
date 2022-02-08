#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0-buster-slim AS build
WORKDIR /src
COPY ["BudgetApp/BudgetApp.csproj", "BudgetApp/"]
RUN dotnet restore "BudgetApp/BudgetApp.csproj"
COPY . .
WORKDIR "/src/BudgetApp"
RUN dotnet build "BudgetApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BudgetApp.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BudgetApp.dll"]