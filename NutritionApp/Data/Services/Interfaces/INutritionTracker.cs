using Nutrition.Core;

namespace NutritionApp.Data.Services;

public interface INutritionTracker
{
    Task AddFood(FoodItem food);

    Task RemoveFood(FoodItem food);

    Task UpdateFood(FoodItem food);

    Task<NutritionDayV1> GetSelectedNutritionDay();

    NutritionDayV1 NextDay();

    Task<NutritionDayV1> PreviousDay();
}