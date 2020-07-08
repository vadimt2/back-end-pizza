#
#FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
#WORKDIR /app
#EXPOSE 80
#
#FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
#WORKDIR /src
#COPY ["PizzaWebAPI/PizzaWebAPI.csproj", "PizzaWebAPI/"]
#COPY ["DAL/DAL.csproj", "DAL/"]
#COPY ["Common/Common.csproj", "Common/"]
#COPY ["Infrastructure/Infrastructure.csproj", "Infrastructure/"]
#COPY ["BL/BL.csproj", "BL/"]
#RUN dotnet restore "PizzaWebAPI/PizzaWebAPI.csproj"
#COPY . .
#WORKDIR "/src/PizzaWebAPI"
#RUN dotnet build "PizzaWebAPI.csproj" -c Release -o /app/build
#
#FROM build AS publish
#RUN dotnet publish "PizzaWebAPI.csproj" -c Release -o /app/publish
#
#FROM base AS final
#WORKDIR /app
#COPY --from=publish /app/publish .
#ENTRYPOINT ["dotnet", "PizzaWebAPI.dll"]
#
#
#


FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
COPY . .
CMD ASPNETCORE_URLS=http://*:$PORT dotnet PizzaWebAPI.dll