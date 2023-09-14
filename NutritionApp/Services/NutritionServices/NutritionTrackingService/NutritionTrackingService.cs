using CommunityToolkit.Mvvm.ComponentModel;
using NutritionApp.MVVM.Models;

namespace NutritionApp.Services.NutritionServices.NutritionTrackingService;

public class NutritionTrackingService : ObservableObject, INutritionTracker
{
    public event EventHandler ItemAdded;
    public List<FoodItem> ConsumedFoods { get; set; } = new List<FoodItem>();
    public double TotalKcal => ConsumedFoods.Sum(food => CalculateActualNutrition(food.Calories, food.Amount));
    public double TotalProtein => ConsumedFoods.Sum(food => CalculateActualNutrition(food.Protein, food.Amount));
    public double TotalCarbs => ConsumedFoods.Sum(food => CalculateActualNutrition(food.Carbohydrates.Carbohydrate, food.Amount));
    public double TotalFat => ConsumedFoods.Sum(food => CalculateActualNutrition(food.Fats.TotalFat, food.Amount));
    public double TotalVitaminE => ConsumedFoods.Sum(food => CalculateActualNutrition(food.Vitamins.VitaminE, food.Amount));
    public double TotalVitaminC => ConsumedFoods.Sum(food => CalculateActualNutrition(food.Vitamins.VitaminC, food.Amount));

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

    private double CalculateActualNutrition(double nutritionAmount, double amountConsumed) => nutritionAmount / 100 * amountConsumed;
}
