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
    public double TotalVitaminA => ConsumedFoods.Sum(food => CalculateActualNutrition(food.Vitamins.VitaminA, food.Amount));
    public double TotalVitaminD => ConsumedFoods.Sum(food => CalculateActualNutrition(food.Vitamins.VitaminD, food.Amount));
    public double TotalVitaminE => ConsumedFoods.Sum(food => CalculateActualNutrition(food.Vitamins.VitaminE, food.Amount));
    public double TotalVitaminC => ConsumedFoods.Sum(food => CalculateActualNutrition(food.Vitamins.VitaminC, food.Amount));
    public double TotalVitaminK => ConsumedFoods.Sum(food => CalculateActualNutrition(food.Vitamins.VitaminK, food.Amount));
    public double TotalThiamin => ConsumedFoods.Sum(food => CalculateActualNutrition(food.Vitamins.Thiamin, food.Amount));
    public double TotalRiboflavin => ConsumedFoods.Sum(food => CalculateActualNutrition(food.Vitamins.Riboflavin, food.Amount));
    public double TotalNiacin => ConsumedFoods.Sum(food => CalculateActualNutrition(food.Vitamins.Niacin, food.Amount));
    public double TotalPantothenicAcid => ConsumedFoods.Sum(food => CalculateActualNutrition(food.Vitamins.PantothenicAcid, food.Amount));
    public double TotalFolate => ConsumedFoods.Sum(food => CalculateActualNutrition(food.Vitamins.Folate, food.Amount));
    public double TotalVitaminB12 => ConsumedFoods.Sum(food => CalculateActualNutrition(food.Vitamins.VitaminB12, food.Amount));
    public double TotalTocopherolAlpha => ConsumedFoods.Sum(food => CalculateActualNutrition(food.Vitamins.TocopherolAlpha, food.Amount));

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
