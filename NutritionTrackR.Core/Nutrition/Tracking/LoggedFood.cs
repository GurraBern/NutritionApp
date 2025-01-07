using NutritionTrackR.Core.Foods;
using NutritionTrackR.Core.Foods.ValueObjects;

namespace NutritionTrackR.Core.Nutrition.Tracking;

public class LoggedFood
{
    public Guid LoggedFoodId { get; private set; } = Guid.NewGuid();
    public FoodId FoodId { get; private set; }
    public Weight Weight { get; private set; }
    public MealType MealType { get; private set; }

    private LoggedFood() { }

    private LoggedFood(FoodId foodId, Weight weight, MealType mealType)
    {
        FoodId = foodId;
        Weight = weight;
        MealType = mealType;
    }

    public static LoggedFood Create(FoodId foodId, Weight weight, MealType mealType)
    {
        var foodEntry = new LoggedFood(foodId, weight, mealType);

        return foodEntry;
    }
    
    
    public static LoggedFood Create(Guid loggedFoodId, FoodId foodId, Weight weight, MealType mealType)
    {
        var foodEntry = new LoggedFood(foodId, weight, mealType)
        {
            LoggedFoodId = loggedFoodId
            
        };

        return foodEntry;
    }

    public void UpdateWith(LoggedFood loggedFood)
    {
        LoggedFoodId = loggedFood.LoggedFoodId;
        FoodId = loggedFood.FoodId;
        Weight = loggedFood.Weight;
        MealType = loggedFood.MealType;
    }
}