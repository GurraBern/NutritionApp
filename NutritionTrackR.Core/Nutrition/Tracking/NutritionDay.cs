using NutritionTrackR.Core.Foods;
using NutritionTrackR.Core.Foods.ValueObjects;
using NutritionTrackR.Core.Shared;

namespace NutritionTrackR.Core.Nutrition.Tracking;

public class NutritionDay : AggregateRoot 
{
    //TODO make lists readonly to protect from unwanted manipulation
    public DateTime Date { get; private set; } = DateTime.Now.Date;
    public List<LoggedFood> ConsumedFood { get; } = [];

    public NutritionDay()
    {
    }

    public void LogFood(FoodId foodId, Weight weight, MealType mealType)
    {
        var foodEntry = LoggedFood.Create(foodId, weight, mealType);
        ConsumedFood.Add(foodEntry);
    }

    public void UpdateFood(LoggedFood loggedFood)
    {
        var previousFood = ConsumedFood.First(x => x.LoggedFoodId == loggedFood.LoggedFoodId);
        previousFood.UpdateWith(loggedFood);
    }

    public void DeleteFood(Guid loggedFoodId)
    {
        var food = ConsumedFood.First(x => x.LoggedFoodId == loggedFoodId);
        
        ConsumedFood.Remove(food);
    }
}