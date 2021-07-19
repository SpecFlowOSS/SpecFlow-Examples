FROM mcr.microsoft.com/dotnet/sdk:5.0 AS base
WORKDIR /app 


FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build

RUN dir
WORKDIR /src
COPY ["CommunityContentSubmissionPage/*.csproj", "CommunityContentSubmissionPage/"]
COPY ["CommunityContentSubmissionPage.Database/CommunityContentSubmissionPage.Database.csproj", "CommunityContentSubmissionPage.Database/"]

RUN dotnet restore "CommunityContentSubmissionPage/CommunityContentSubmissionPage.csproj"

COPY . .

WORKDIR "/src/CommunityContentSubmissionPage"
RUN dotnet build -c Debug -o /app/build


FROM build AS publish
RUN dotnet publish -c Debug -o /app/publish



FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .


ENTRYPOINT ["dotnet", "CommunityContentSubmissionPage.dll"]


