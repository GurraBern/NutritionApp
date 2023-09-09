using CommunityToolkit.Mvvm.ComponentModel;
using NutritionApp.Services;

namespace NutritionApp.MVVM.ViewModels;

public partial class NutritionDetailViewModel : BaseViewModel
{
    private readonly INutritionTracker nutritionTracker;

    [ObservableProperty]
    private double consumedKcalPercentage;

    [ObservableProperty]
    private double consumedProteinPercentage;

    [ObservableProperty]
    private double consumedCarbsPercentage;

    [ObservableProperty]
    private double consumedFatPercentage;

    public NutritionDetailViewModel(INutritionTracker nutritionTracker)
    {
        this.nutritionTracker = nutritionTracker;

        nutritionTracker.ItemAdded += (sender, args) =>
        {
            ConsumedKcalPercentage = nutritionTracker.TotalKcal / 2400;
            ConsumedProteinPercentage = nutritionTracker.TotalProtein / 110;
            ConsumedCarbsPercentage = nutritionTracker.TotalCarbs / 240;
            ConsumedFatPercentage = nutritionTracker.TotalFat / 70;
        };
    }
}
