using CommunityToolkit.Mvvm.Input;
using NutritionApp.MVVM.Models;
using NutritionApp.MVVM.ViewModels;
using NutritionApp.Services;

namespace NutritionApp.MVVM.Viewmodels;

public partial class FoodDetailViewModel : BaseViewModel
{
    private readonly INutritionTracker nutritionTracker;

    public FoodItem FoodItem { get; }

    public int ConsumedKcal
    {
        get
        {
            return nutritionTracker.TotalKcal;
        }
    }

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
