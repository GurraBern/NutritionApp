using NutritionApp.MVVM.Models;

namespace NutritionApp.Services.NutritionServices;

public interface INutritionTracker
{
    void AddFood(FoodItem food);
    void RemoveFood(FoodItem food);
    Task<NutritionDay> GetSelectedNutritionDay();
    NutritionDay NextDay();
    Task<NutritionDay> PreviousDay();
}
