using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using NutritionApp.MVVM.Models;
using NutritionApp.MVVM.ViewModels;
using NutritionApp.Services;

namespace NutritionApp.MVVM.Viewmodels;

public partial class FoodDetailViewModel : BaseViewModel
{
    private readonly INutritionTracker nutritionTracker;
    public FoodItem FoodItem { get; }

    [ObservableProperty]
    public int consumedKcal = 0;

    public FoodDetailViewModel(FoodItem foodItem, INutritionTracker nutritionTracker)
    {
        FoodItem = foodItem;
        this.nutritionTracker = nutritionTracker;
    }

    [RelayCommand]
    public async Task AddFoodAsync()
    {
        nutritionTracker.ConsumedFoods.Add(FoodItem);
        ConsumedKcal = nutritionTracker.TotalKcal;

        await Shell.Current.GoToAsync("//MainPage");
    }
}
