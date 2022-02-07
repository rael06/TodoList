FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["MyTodoList.Api/MyTodoList.Api.csproj", "MyTodoList.Api/"]
RUN dotnet restore "MyTodoList.Api/MyTodoList.Api.csproj"
COPY . .
WORKDIR "/src/MyTodoList.Api"
RUN dotnet build "MyTodoList.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MyTodoList.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MyTodoList.Api.dll"]
