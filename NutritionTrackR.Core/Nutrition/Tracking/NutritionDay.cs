using NutritionTrackR.Core.Foods;
using NutritionTrackR.Core.Foods.ValueObjects;
using NutritionTrackR.Core.Shared;
using NutritionTrackR.Core.Shared.Abstractions;
using NutritionTrackR.Core.Shared.ValueObjects;

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

    public Result UpdateFood(LoggedFood loggedFood)
    {
        var previousFood = ConsumedFood.FirstOrDefault(x => x.LoggedFoodId == loggedFood.LoggedFoodId);
        if (previousFood is null) 
            return Result.Failure("Logged food could not be found");
        
        previousFood.UpdateWith(loggedFood);
        return Result.Success();
    }

    public Result DeleteFood(Guid id)
    {
        var food = ConsumedFood.FirstOrDefault(x => x.LoggedFoodId == id);
        if (food is null) 
            return Result.Failure("Logged food could not be removed");
        
        ConsumedFood.Remove(food);
        return Result.Success();
    }
}