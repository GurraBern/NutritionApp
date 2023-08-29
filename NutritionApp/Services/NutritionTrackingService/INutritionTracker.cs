using NutritionApp.MVVM.Models;

namespace NutritionApp.Services;

public interface INutritionTracker
{
    public List<FoodItem> ConsumedFoods { get; set; }

    public int TotalKcal => ConsumedFoods.Sum(food => food.Kcal);
    public int TotalProtein => ConsumedFoods.Sum(food => food.Protein);
    public int TotalCarbs => ConsumedFoods.Sum(food => food.Carbs);
    public int TotalFat => ConsumedFoods.Sum(food => food.Fat);
}
