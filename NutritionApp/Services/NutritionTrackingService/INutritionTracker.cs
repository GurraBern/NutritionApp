using NutritionApp.MVVM.Models;

namespace NutritionApp.Services;

public interface INutritionTracker
{
    public event EventHandler ItemAdded;
    public List<FoodItem> ConsumedFoods { get; set; }

    public double TotalKcal => ConsumedFoods.Sum(food => food.Calories);
    public double TotalProtein => ConsumedFoods.Sum(food => food.Protein);
    public double TotalCarbs => ConsumedFoods.Sum(food => food.Carbohydrates.Carbohydrate);
    public double TotalFat => ConsumedFoods.Sum(food => food.Fats.TotalFat);
    public void AddFood(FoodItem food);
    public void RemoveFood(FoodItem food);
}
