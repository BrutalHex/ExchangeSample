#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
ARG BUILD_CONFIGURATION=Debug
ENV ASPNETCORE_ENVIRONMENT=Development
ENV DOTNET_USE_POLLING_FILE_WATCHER=true  
ENV ASPNETCORE_URLS=http://+:80  
EXPOSE 5001
EXPOSE 5000
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["API/02.Services/KnabExchange/Knab.Exchange.Endpoint/Knab.Exchange.Endpoint.csproj", "API/02.Services/KnabExchange/Knab.Exchange.Endpoint/"]
COPY ["API/01.Framework/Knab.Framework.Core/Knab.Framework.Core.csproj", "API/01.Framework/Knab.Framework.Core/"]
COPY ["API/02.Services/KnabExchange/Knab.Exchange.Application/Knab.Exchange.Application.csproj", "API/02.Services/KnabExchange/Knab.Exchange.Application/"]
COPY ["API/02.Services/KnabExchange/Knab.Exchange.ApplicationContract/Knab.Exchange.ApplicationContract.csproj", "API/02.Services/KnabExchange/Knab.Exchange.ApplicationContract/"]
COPY ["API/02.Services/KnabExchange/Knab.Exchange.Domain/Knab.Exchange.Domain.csproj", "API/02.Services/KnabExchange/Knab.Exchange.Domain/"]
RUN dotnet restore "API/02.Services/KnabExchange/Knab.Exchange.Endpoint/Knab.Exchange.Endpoint.csproj"
COPY . .
WORKDIR "/src/API//02.Services/KnabExchange/Knab.Exchange.Endpoint"
RUN dotnet build "Knab.Exchange.Endpoint.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Knab.Exchange.Endpoint.csproj" -c Release -o /app/publish


FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Knab.Exchange.Endpoint.dll"]