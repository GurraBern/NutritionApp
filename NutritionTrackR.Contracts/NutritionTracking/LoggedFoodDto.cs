using NutritionTrackR.Contracts.Food;

namespace NutritionTrackR.Contracts.NutritionTracking;

public record FoodEntryDto(DateTimeOffset LoggedAt, string FoodId, double Weight, UnitDto Unit, MealTypeDto MealType);