using NutritionTrackR.Core.Food;
using NutritionTrackR.Core.Food.ValueObjects;
using NutritionTrackR.Core.Shared;

namespace NutritionTrackR.Core.NutrientTracking.Events;

public class FoodLoggedEvent : BaseDomainEvent
{
	public string FoodId { get; set; }
	public Weight Weight { get; set; }
	public MealType MealType { get; set; }
	
	public FoodLoggedEvent() { }
	
	public FoodLoggedEvent(string foodId, Weight weight, MealType mealType)
	{
		FoodId = foodId;
		Weight = weight;
		MealType = mealType;
	}
}