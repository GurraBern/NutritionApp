# Use the Microsoft .NET Core SDK image as the build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /app

# Copy only the necessary project files and restore as distinct layers
COPY Nutrition.Core/Nutrition.Core.csproj Nutrition.Core/
COPY PersonalHealthAPI/PersonalHealthAPI.csproj PersonalHealthAPI/
RUN dotnet restore PersonalHealthAPI/PersonalHealthAPI.csproj

# Copy the entire project source code
COPY . .

# Build the PersonalHealthAPI project without building NutritionApp
WORKDIR /app/PersonalHealthAPI
RUN dotnet publish -c Release -o out

# Generate runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build-env /app/PersonalHealthAPI/out .
ENTRYPOINT ["dotnet", "PersonalHealthAPI.dll"]