# Backend - Trabajo 9-5-26
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src
COPY .. .
RUN dotnet restore "Trabajo 9-5-26.csproj"
RUN dotnet publish "Trabajo 9-5-26.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final
WORKDIR /app
ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "Trabajo 9-5-26.dll"]
