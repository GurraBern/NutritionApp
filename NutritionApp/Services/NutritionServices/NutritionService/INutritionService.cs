using Nutrition.Core;

namespace NutritionApp.Services.NutritionServices;

public interface INutritionService
{
    public Task<IEnumerable<FoodItem>> GetSearchResults(string query);
    public Task<IEnumerable<FoodItem>> GetFood();
}