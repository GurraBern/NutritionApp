using CommunityToolkit.Mvvm.Input;
using NutritionApp.MVVM.Models;

namespace NutritionApp.MVVM.Viewmodels;

public partial class FoodDetailViewModel
{
    private readonly INutritionTracker nutritionTracker;

    public FoodItem FoodItem { get; }

    public int ConsumedKcal { get => nutritionTracker.TotalKcal; }

    public FoodDetailViewModel(FoodItem foodItem, INutritionTracker nutritionTracker)
    {
        FoodItem = foodItem;
        this.nutritionTracker = nutritionTracker;
    }

    [RelayCommand]
    public void AddFood()
    {
        nutritionTracker.ConsumedFoods.Add(FoodItem);
    }
}
