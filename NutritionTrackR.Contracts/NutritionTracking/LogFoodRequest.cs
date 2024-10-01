using NutritionTrackR.Contracts.Food;

namespace NutritionTrackR.Contracts.NutritionTracking;

public class LogFoodRequest
{
	public string FoodId { get; set; }
	public double Weight { get; set; }   
	public UnitDto Unit { get; set; }
	public MealTypeDto? MealType { get; set; }
}