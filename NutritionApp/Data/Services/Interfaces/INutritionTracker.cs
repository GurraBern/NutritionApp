using Nutrition.Core;

namespace NutritionApp.Data.Services;

public interface INutritionTracker
{
    Task AddFood(FoodItem food);

    Task RemoveFood(FoodItem food);

    Task UpdateFood(FoodItem food);

    Task<NutritionDay> GetSelectedNutritionDay();

    NutritionDay NextDay();

    Task<NutritionDay> PreviousDay();
}