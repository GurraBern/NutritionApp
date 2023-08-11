using NutritionApp.MVVM.Models;

namespace NutritionApp.Services;

public interface INutritionService
{
    public ICollection<FoodItem> GetSearchResults(string query);
}