using NutritionTrackR.Core.Foods;
using NutritionTrackR.Core.Foods.ValueObjects;

namespace NutritionTrackR.Core.NutrientTracking;

public class EatenFoodEntry
{
    public FoodId FoodId { get; private set; }
    public Weight Weight { get; private set; }
    public MealType MealType { get; private set; }

    private EatenFoodEntry() { }

    private EatenFoodEntry(FoodId foodId, Weight weight, MealType mealType)
    {
        FoodId = foodId;
        Weight = weight;
        MealType = mealType;
    }

    public static EatenFoodEntry Create(FoodId foodId, Weight weight, MealType mealType)
    {
        var foodEntry = new EatenFoodEntry(foodId, weight, mealType);

        return foodEntry;
    }
}