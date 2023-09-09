using CommunityToolkit.Mvvm.Input;
using NutritionApp.MVVM.Models;
using NutritionApp.Services;

namespace NutritionApp.MVVM.ViewModels;

public partial class FoodDetailViewModel : BaseViewModel
{
    private readonly INutritionTracker nutritionTracker;
    private int amount = 100;
    public FoodItem FoodItem { get; }
    public double ToBeAddedPercentage => (nutritionTracker.TotalKcal + Amount * FoodItem.Calories / 100) / 2400;
    public double ConsumedPercentage => nutritionTracker.TotalKcal / 2400;
    public int Amount
    {
        get => amount;
        set
        {
            if (amount != value)
            {
                amount = value;
                OnPropertyChanged(nameof(ToBeAddedPercentage));
                OnPropertyChanged(nameof(ConsumedPercentage));
            }
        }
    }

    public FoodDetailViewModel(FoodItem foodItem, INutritionTracker nutritionTracker)
    {
        FoodItem = foodItem;
        this.nutritionTracker = nutritionTracker;
    }

    [RelayCommand]
    public async Task AddFood()
    {
        nutritionTracker.AddFood(FoodItem);

        await Shell.Current.GoToAsync("//MainPage");
    }
}
