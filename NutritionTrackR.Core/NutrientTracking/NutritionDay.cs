using NutritionTrackR.Core.Food;
using NutritionTrackR.Core.Foods.ValueObjects;
using NutritionTrackR.Core.NutrientTracking.Events;
using NutritionTrackR.Core.Shared;

namespace NutritionTrackR.Core.NutrientTracking;

public class NutritionDay : Entity
{
	//TODO make lists readonly to protect from unwanted manipulation
	public DateTimeOffset Date { get; init; }
	public List<IDomainEvent> DomainEvents { get; set; } = [];
	public NutritionDayState NutritionDayState; // TODO use projection


	public NutritionDay(IEnumerable<IDomainEvent> events)
	{
		NutritionDayState = new NutritionDayState();
		foreach (var @event in events)
		{
			AppendEvent(@event);
		}
	}

	private void AppendEvent(IDomainEvent @event)
	{
		DomainEvents.Add(@event);
		NutritionDayState.Apply((dynamic)@event);
	}

	public void LogFood(string foodId, Weight weight, MealType mealType)
	{
		var foodLoggedEvent = new FoodLoggedEvent
		{
			FoodId = foodId,
			Weight = weight,
			MealType = mealType,
			OccurredAt = DateTimeOffset.Now //TODO users should be able to override 
		};

		DomainEvents.Add(foodLoggedEvent);
	}

	public void RemoveLoggedFood(string foodId, Weight weight, MealType mealType)
	{
		var foodLoggedEvent = new FoodLoggedEvent
		{
			FoodId = foodId,
			Weight = weight,
			MealType = mealType,
			OccurredAt = DateTimeOffset.Now
		};

		DomainEvents.Add(foodLoggedEvent);
	}

	public void ClearDomainEvents()
	{
		DomainEvents.Clear();
	}
}

public class NutritionDayState
{
	public List<Nutrient> Nutrients { get; set; } = [];

	public void Apply(FoodLoggedEvent @event)
	{
		
	}

	public void Apply(RemoveFoodLoggedEvent @event)
	{
		
	}
}