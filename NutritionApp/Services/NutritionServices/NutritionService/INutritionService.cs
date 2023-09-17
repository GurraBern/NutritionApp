using NutritionApp.MVVM.Models;

namespace NutritionApp.Services.NutritionServices.NutritionService;

public interface INutritionService
{
    public Task<IEnumerable<FoodItem>> GetSearchResults(string query);
    public Task<IEnumerable<FoodItem>> GetFood();
}