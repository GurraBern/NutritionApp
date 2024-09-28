using NutritionTrackR.Core.Food;
using NutritionTrackR.Core.Food.ValueObjects;

namespace NutritionTrackR.Contracts.NutritionTracking;

public class FoodEntryRequest
{
	public string FoodId { get; set; }
	public decimal Weight { get; set; }   
	public Unit Unit { get; set; }
	public MealType? MealType { get; set; }
}