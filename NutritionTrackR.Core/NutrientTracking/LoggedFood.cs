using NutritionTrackR.Core.Foods;
using NutritionTrackR.Core.Foods.ValueObjects;

namespace NutritionTrackR.Core.NutrientTracking;

public class LoggedFood
{
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
}