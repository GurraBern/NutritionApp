using NutritionTrackR.Core.Food.Events;
using NutritionTrackR.Core.Food.ValueObjects;
using NutritionTrackR.Core.Shared;

namespace NutritionTrackR.Core.NutritionDay.Events;

public class RemoveFoodLoggedEvent : BaseDomainEvent
{
	public string FoodId { get; set; }
	public Weight Weight { get; set; }
	public MealType MealType { get; set; }
	
	public RemoveFoodLoggedEvent() { }
	
	public RemoveFoodLoggedEvent(string foodId, Weight weight, MealType mealType)
	{
		FoodId = foodId;
		Weight = weight;
		MealType = mealType;
	}
}
