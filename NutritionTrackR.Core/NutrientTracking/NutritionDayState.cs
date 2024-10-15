using NutritionTrackR.Core.Foods.ValueObjects;
using NutritionTrackR.Core.NutrientTracking.Events;
using NutritionTrackR.Core.Shared;

namespace NutritionTrackR.Core.NutrientTracking;

public class NutritionDayState
{
	private List<Foods.Food> Foods { get; init; }
	public List<Nutrient> Nutrients { get; set; } = [];

	private NutritionDayState(List<Foods.Food> foods)
	{
		Foods = foods;
	}
	
	public void Apply(FoodLoggedEvent @event, Foods.Food food)
	{
		
	}

	public void Apply(RemoveFoodLoggedEvent @event)
	{
		
	}

	public NutritionDayState CreateState(List<DomainEvent> events, List<Foods.Food> foods)
	{
		var state = new NutritionDayState(foods);
		foreach (var @event in events)
		{
			state.Apply((dynamic)@event);
		}

		return state;
	}
}