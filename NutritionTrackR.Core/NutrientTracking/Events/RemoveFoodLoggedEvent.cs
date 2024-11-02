using NutritionTrackR.Core.Foods;
using NutritionTrackR.Core.Foods.ValueObjects;
using NutritionTrackR.Core.Shared;

namespace NutritionTrackR.Core.NutrientTracking.Events;

public class RemoveFoodLoggedEvent : DomainEvent 
{
	public string FoodId { get; set; }
	public Weight Weight { get; set; }
	public MealType MealType { get; set; }
	public DateTimeOffset OccurredAt { get; set; }
	
	public RemoveFoodLoggedEvent() { }
	
	public RemoveFoodLoggedEvent(string foodId, Weight weight, MealType mealType)
	{
		FoodId = foodId;
		Weight = weight;
		MealType = mealType;
	}

}
