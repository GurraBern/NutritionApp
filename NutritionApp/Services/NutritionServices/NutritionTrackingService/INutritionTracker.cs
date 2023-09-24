using NutritionApp.MVVM.Models;

namespace NutritionApp.Services.NutritionServices.NutritionTrackingService;

public interface INutritionTracker
{
    public Dictionary<string, double> NutrientNeeds { get; set; }
    public NutritionDay NutritionDay { get; set; }
    public void AddFood(FoodItem food);
    public void RemoveFood(FoodItem food);
}
