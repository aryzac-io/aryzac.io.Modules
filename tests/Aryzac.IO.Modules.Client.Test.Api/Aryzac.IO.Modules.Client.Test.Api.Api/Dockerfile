#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Aryzac.IO.Modules.Client.Test.Api.Api.csproj", "Aryzac.IO.Modules.Client.Test.Api.Api/"]
RUN dotnet restore "Aryzac.IO.Modules.Client.Test.Api.Api/Aryzac.IO.Modules.Client.Test.Api.Api.csproj"
COPY . .
WORKDIR "/src/Aryzac.IO.Modules.Client.Test.Api.Api"
RUN dotnet build "Aryzac.IO.Modules.Client.Test.Api.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Aryzac.IO.Modules.Client.Test.Api.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app/publish
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Aryzac.IO.Modules.Client.Test.Api.Api.dll"]