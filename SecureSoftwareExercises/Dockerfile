FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["SecureSoftwareExercises/SecureSoftwareExercises.csproj", "SecureSoftwareExercises/"]
RUN dotnet restore "SecureSoftwareExercises/SecureSoftwareExercises.csproj"
COPY . .
WORKDIR "/src/SecureSoftwareExercises"
RUN dotnet build "SecureSoftwareExercises.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SecureSoftwareExercises.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SecureSoftwareExercises.dll"]
