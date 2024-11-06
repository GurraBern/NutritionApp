using NutritionTrackR.Contracts.Food;

namespace NutritionTrackR.Contracts.NutritionTracking;

public class LogFoodRequest(string foodId, decimal weight, UnitDto unit, MealTypeDto mealType)
{
	public string FoodId { get; set; } = foodId;
	public decimal Weight { get; set; } = weight;
	public UnitDto Unit { get; set; } = unit;
	public MealTypeDto MealType { get; set; } = mealType;
}