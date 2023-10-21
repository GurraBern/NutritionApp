# Use the Microsoft .NET Core SDK image as the build stage
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env
WORKDIR /app

# Copy only the necessary project files and restore as distinct layers
COPY Nutrition.Core/Nutrition.Core.csproj Nutrition.Core/
COPY UserNutritionAPI/UserNutritionAPI.csproj UserNutritionAPI/
RUN dotnet restore UserNutritionAPI/UserNutritionAPI.csproj

# Copy the entire project source code
COPY . .

# Build the UserNutritionAPI project without building NutritionApp
WORKDIR /app/UserNutritionAPI
RUN dotnet publish -c Release -o out

# Generate runtime image
FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app
COPY --from=build-env /app/UserNutritionAPI/out .
ENTRYPOINT ["dotnet", "UserNutritionAPI.dll"]