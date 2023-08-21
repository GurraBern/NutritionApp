using NutritionApp.MVVM.Models;

namespace NutritionApp.MVVM.Viewmodels;

public class FoodDetailViewModel
{
    public FoodItem FoodItem { get; }
    public FoodDetailViewModel(FoodItem foodItem)
    {
        FoodItem = foodItem;
    }
}
