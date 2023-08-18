using NutritionApp.MVVM.Models;

namespace NutritionApp.MVVM.Viewmodels;

public class FoodDetailViewModel
{
    public FoodItem foodItem { get; set; }
    public FoodDetailViewModel(FoodItem foodItem)
    {
        this.foodItem = foodItem;
    }
}
