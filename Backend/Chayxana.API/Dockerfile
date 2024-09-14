FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS build
WORKDIR /src
COPY ["Chayxana.API/Chayxana.API.csproj", "Chayxana.API"]
COPY ["Chayxana.BLL/Chayxana.BLL.csproj", "Chayxana.BLL"]
COPY ["Chayxana.DAL/Chayxana.DAL.csproj", "Chayxana.DAL"]
COPY ["Chayxana.Infrastructure/Chayxana.Infrastructure.csproj", "Chayxana.Infrastructure"]
COPY ["Chayxana.Domain/Chayxana.Domain.csproj", "Chayxana.Domain"]
RUN dotnet restore "Chayxana.API/Chayxana.API.csproj"
COPY . .
WORKDIR "/src/Chayxana.API"
RUN dotnet build "Chayxana.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet build "Chayxana.API.csproj" -c Release -o /app/build /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Chayxana.API.dll"]