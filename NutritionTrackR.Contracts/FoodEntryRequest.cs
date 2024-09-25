using NutritionTrackR.Core.Food.Events;
using Unit = NutritionTrackR.Core.Food.ValueObjects.Unit;

namespace NutritionTrackR.Contracts;

public class FoodEntryRequest
{
	public string FoodId { get; set; }
	public decimal Weight { get; set; }   
	public Unit Unit { get; set; }
	public MealType? MealType { get; set; }
}