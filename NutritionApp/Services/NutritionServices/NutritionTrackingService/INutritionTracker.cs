using NutritionApp.MVVM.Models;

namespace NutritionApp.Services.NutritionServices.NutritionTrackingService;

public interface INutritionTracker
{
    public event EventHandler ItemAdded;
    public List<FoodItem> ConsumedFoods { get; set; }
    public double TotalKcal => ConsumedFoods.Sum(food => food.Calories);
    public double TotalProtein => ConsumedFoods.Sum(food => food.Protein);
    public double TotalCarbs => ConsumedFoods.Sum(food => food.Carbohydrates.Carbohydrate);
    public double TotalFat => ConsumedFoods.Sum(food => food.Fats.TotalFat);
    public double TotalVitaminA => ConsumedFoods.Sum(food => food.Vitamins.VitaminA);
    public double TotalVitaminD => ConsumedFoods.Sum(food => food.Vitamins.VitaminD);
    public double TotalVitaminE => ConsumedFoods.Sum(food => food.Vitamins.VitaminE);
    public double TotalVitaminC => ConsumedFoods.Sum(food => food.Vitamins.VitaminC);
    public double TotalVitaminK => ConsumedFoods.Sum(food => food.Vitamins.VitaminK);

    public void AddFood(FoodItem food);
    public void RemoveFood(FoodItem food);
}
