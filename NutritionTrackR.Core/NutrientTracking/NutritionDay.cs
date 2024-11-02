using NutritionTrackR.Core.Food;
using NutritionTrackR.Core.Foods.ValueObjects;
using NutritionTrackR.Core.Shared;

namespace NutritionTrackR.Core.NutrientTracking;

public class NutritionDay : AggregateRoot 
{
    //TODO make lists readonly to protect from unwanted manipulation
    public DateTime Date { get; private set; } = DateTime.Now.Date;
    public List<EatenFoodEntry> ConsumedFood { get; } = [];

    public NutritionDay()
    {
    }

    public void LogFood(string foodId, Weight weight, MealType mealType)
    {
        var foodEntry = EatenFoodEntry.Create(foodId, weight, mealType);
        ConsumedFood.Add(foodEntry);
    }
}