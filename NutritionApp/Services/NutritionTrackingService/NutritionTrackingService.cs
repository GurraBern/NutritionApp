using CommunityToolkit.Mvvm.ComponentModel;
using NutritionApp.MVVM.Models;

namespace NutritionApp.Services.NutritionTrackingService;

public class NutritionTrackingService : ObservableObject, INutritionTracker
{
    public event EventHandler ItemAdded;
    public List<FoodItem> ConsumedFoods { get; set; } = new List<FoodItem>();

    public double TotalKcal => ConsumedFoods.Sum(food => food.Calories);
    public double TotalProtein => ConsumedFoods.Sum(food => food.Protein);
    public double TotalCarbs => ConsumedFoods.Sum(food => food.Carbohydrates.Carbohydrate);
    public double TotalFat => ConsumedFoods.Sum(food => food.Fats.TotalFat);

    public double KcalNeeded => 2400;

    public NutritionSettings nutritionSettings;

    public NutritionTrackingService()
    {

    }

    public void AddFood(FoodItem food)
    {
        ConsumedFoods.Add(food);
        ItemAdded?.Invoke(this, EventArgs.Empty);
    }

    public void RemoveFood(FoodItem food)
    {
        ConsumedFoods.Remove(food);
        ItemAdded?.Invoke(this, EventArgs.Empty);
    }
}
