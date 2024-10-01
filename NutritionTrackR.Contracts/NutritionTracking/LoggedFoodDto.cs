using NutritionTrackR.Contracts.Food;

namespace NutritionTrackR.Contracts.NutritionTracking;

public record LoggedFoodDto(DateTimeOffset LoggedAt, string FoodId, double Weight, UnitDto Unit, MealTypeDto MealType);