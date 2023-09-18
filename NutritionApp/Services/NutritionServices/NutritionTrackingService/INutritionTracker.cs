using NutritionApp.MVVM.Models;

namespace NutritionApp.Services.NutritionServices.NutritionTrackingService;

public interface INutritionTracker
{
    public event EventHandler ItemAdded;
    public List<FoodItem> ConsumedFoods { get; set; }
    public Dictionary<string, double> NutrientTotals { get; set; }
    public Dictionary<string, double> NutrientNeeds { get; set; }
    public void AddFood(FoodItem food);
    public void RemoveFood(FoodItem food);
}
