using NutritionTrackR.Core.Food;
using NutritionTrackR.Core.Foods.ValueObjects;
using NutritionTrackR.Core.NutrientTracking.Events;
using NutritionTrackR.Core.Shared;

namespace NutritionTrackR.Core.NutrientTracking;

public class NutritionDay : Entity
{
    //TODO make lists readonly to protect from unwanted manipulation
    public DateTime Date { get; set; } = DateTime.Now.Date;
    public List<DomainEvent> DomainEvents { get; set; } = [];

    public NutritionDay()
    {
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