# Estágio de Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copia o arquivo de projeto de dentro da pasta e restaura
# O segredo está no caminho: "Pasta/Arquivo.csproj"
COPY ["DesafioFastBack/DesafioFastBack.csproj", "DesafioFastBack/"]
RUN dotnet restore "DesafioFastBack/DesafioFastBack.csproj"

# Copia todo o conteúdo para o container
COPY . .

# Muda para a pasta do projeto para compilar
WORKDIR "/src/DesafioFastBack"
RUN dotnet build "DesafioFastBack.csproj" -c Release -o /app/build

# Publica a aplicação
FROM build AS publish
RUN dotnet publish "DesafioFastBack.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Estágio Final
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .

ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080

ENTRYPOINT ["dotnet", "DesafioFastBack.dll"]
