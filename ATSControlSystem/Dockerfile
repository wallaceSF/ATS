FROM mcr.microsoft.com/dotnet/sdk:6.0 AS builder
WORKDIR /src
COPY . .

ENV ASPNETCORE_URLS=http://+:5196

WORKDIR "/src/ATSControlSystem.Api"
RUN ["rm", "-rf", "obj"]
RUN ["rm", "-rf", "bin"]
RUN ["dotnet", "restore"]
RUN ["dotnet", "publish", "ATSControlSystem.Api.csproj", "-c", "Release", "-o", "/out"]

ENV ASPNETCORE_URLS=http://+:5196

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /out
COPY --from=builder /out .
ENTRYPOINT ["dotnet", "ATSControlSystem.Api.dll"]
