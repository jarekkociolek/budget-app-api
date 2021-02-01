FROM mcr.microsoft.com/dotnet/sdk:5.0 AS BUILD
WORKDIR /app
COPY . .
RUN dotnet publish src/BudgetApp.Api -o output

FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app
COPY --from=build /app/output .
ENV ASPNETCORE_URLS http://*:80
ENV ASPNETCORE_ENVIRONMENT docker
ENTRYPOINT dotnet BudgetApp.Api.dll