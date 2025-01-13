using NutritionTrackR.Contracts.Food;

namespace NutritionTrackR.Contracts.Nutrition.NutritionTracking;

public record LogFoodRequest(string FoodId, decimal Weight, string Unit, MealTypeDto MealType, DateTime Date);