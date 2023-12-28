using Nutrition.Core;

namespace NutritionApp.Services.NutritionServices;

public interface INutritionTracker
{
    Task AddFood(FoodItem food);

    Task RemoveFood(FoodItem food);

    Task UpdateFood(FoodItem food);

    Task<NutritionDay> GetSelectedNutritionDay();

    NutritionDay NextDay();

    Task<NutritionDay> PreviousDay();
}