FROM mcr.microsoft.com/dotnet/sdk:5.0

WORKDIR /src
COPY "./ZennoLabWebAPI/ZennoLabWebAPI/" "./WebAPI/"
RUN dotnet restore "./WebAPI/ZennoLabWebAPI.csproj"
RUN dotnet publish "./WebAPI/ZennoLabWebAPI.csproj" -o "/app/bin/"

WORKDIR /app/bin
ENTRYPOINT [ "dotnet", "ZennoLabWebAPI.dll", "--urls", "http://*:80" ]