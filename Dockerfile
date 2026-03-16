# Estágio de Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copia o arquivo de projeto e restaura as dependências
COPY ["DesafioFastBack.csproj", "./"]
RUN dotnet restore "DesafioFastBack.csproj"

# Copia todo o código e compila
COPY . .
RUN dotnet build "DesafioFastBack.csproj" -c Release -o /app/build

# Publica a aplicação
FROM build AS publish
RUN dotnet publish "DesafioFastBack.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Estágio Final (Imagem leve de execução)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .

# Define a porta padrão do container
ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080

ENTRYPOINT ["dotnet", "DesafioFastBack.dll"]
