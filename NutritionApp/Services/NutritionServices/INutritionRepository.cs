using NutritionApp.MVVM.Models;

namespace NutritionApp.Services.NutritionServices;

public interface INutritionRepository
{
    Task<IEnumerable<FoodItem>> GetConsumedFood();
    Task InsertConsumedFood(FoodItem foodItem);
}
