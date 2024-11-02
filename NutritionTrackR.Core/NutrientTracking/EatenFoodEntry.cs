using MongoDB.Bson;
using NutritionTrackR.Core.Food;
using NutritionTrackR.Core.Foods.ValueObjects;

namespace NutritionTrackR.Core.NutrientTracking;

public class EatenFoodEntry
{
    public string FoodId { get; private set; }
    public Weight Weight { get; private set; }
    public MealType MealType { get; private set; }

    private EatenFoodEntry()
    {
        
    }

    private EatenFoodEntry(string foodId, Weight weight, MealType mealType)
    {
        FoodId = foodId;
        Weight = weight;
        MealType = mealType;
    }

    public static EatenFoodEntry Create(string foodId, Weight weight, MealType mealType)
    {
        var foodEntry = new EatenFoodEntry(foodId, weight, mealType);

        return foodEntry;
    }
}