FROM microsoft/aspnetcore:2.0 AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/aspnetcore-build:2.0 AS build
WORKDIR /src
COPY PathWays.sln ./
COPY PathWays/PathWays.csproj PathWays/
COPY PathWays.Data.Model/PathWays.Data.Model.csproj PathWays.Data.Model/
COPY PathWays.Common.Utilities/PathWays.Common.Utilities.csproj PathWays.Common.Utilities/
COPY PathWays.UserResolverService/PathWays.UserResolverService.csproj PathWays.UserResolverService/
COPY PathWays.Data.Repositories/PathWays.Data.Repositories.csproj PathWays.Data.Repositories/
COPY PathWays.Services/PathWays.Services.csproj PathWays.Services/
COPY GraphQL/GraphQL.AspNetCore.Graphiql/GraphQL.AspNetCore.Graphiql.csproj GraphQL/GraphQL.AspNetCore.Graphiql/
COPY GraphQL/GraphQl.AspNetCore/GraphQl.AspNetCore.csproj GraphQL/GraphQl.AspNetCore/
COPY GraphQL/GraphQL.Authorization/GraphQL.Authorization.csproj GraphQL/GraphQL.Authorization/
COPY GraphQL/GraphQL.Authorization.Extension/GraphQL.Authorization.Extension.csproj GraphQL/GraphQL.Authorization.Extension/
RUN dotnet restore -nowarn:msb3202,nu1503
COPY . .
WORKDIR /src/PathWays
RUN dotnet build -c Release -o /app

FROM build AS publish
RUN dotnet publish -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "PathWays.dll"]
