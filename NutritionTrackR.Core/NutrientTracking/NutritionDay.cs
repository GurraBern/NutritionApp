using NutritionTrackR.Core.Food.Events;
using NutritionTrackR.Core.Food.ValueObjects;
using NutritionTrackR.Core.NutritionDay.Events;
using NutritionTrackR.Core.Shared;

namespace NutritionTrackR.Core.NutrientTracking;

public class NutritionDay : Entity
{
	//TODO make lists readonly to protect from unwanted manipulation
	public List<FoodLoggedEvent> LoggedFoodEvents { get; set; } = [];

	public void LogFood(string foodId, Weight weight, MealType mealType)
	{
		var foodLoggedEvent = new FoodLoggedEvent
		{
			FoodId = foodId,
			Weight = weight,
			MealType = mealType
		};

		LoggedFoodEvents.Add(foodLoggedEvent);
	}

	public void RemoveLoggedFood(string foodId, Weight weight, MealType mealType)
	{
		var foodLoggedEvent = new FoodLoggedEvent
		{
			FoodId = foodId,
			Weight = weight,
			MealType = mealType
		};

		LoggedFoodEvents.Add(foodLoggedEvent);
	}

	public void ClearDomainEvents()
	{
		LoggedFoodEvents.Clear();
	}
}