#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["CloudExample1.csproj", "."]
RUN dotnet restore "./CloudExample1.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "CloudExample1.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CloudExample1.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CloudExample1.dll"]