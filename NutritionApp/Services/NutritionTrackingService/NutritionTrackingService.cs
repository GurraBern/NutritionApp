using CommunityToolkit.Mvvm.ComponentModel;
using NutritionApp.MVVM.Models;

namespace NutritionApp.Services.NutritionTrackingService;

public class NutritionTrackingService : ObservableObject, INutritionTracker
{
    public List<FoodItem> ConsumedFoods { get; set; } = new List<FoodItem>();

    public int TotalKcal => ConsumedFoods.Sum(food => food.Kcal);
    public int TotalProtein => ConsumedFoods.Sum(food => food.Protein);
    public int TotalCarbs => ConsumedFoods.Sum(food => food.Carbs);
    public int TotalFat => ConsumedFoods.Sum(food => food.Fat);

    public NutritionTrackingService()
    {

    }

    public void AddFood(FoodItem food)
    {
        ConsumedFoods.Add(food);
    }

    public void RemoveFood(FoodItem food)
    {
        ConsumedFoods.Remove(food);
    }
}
