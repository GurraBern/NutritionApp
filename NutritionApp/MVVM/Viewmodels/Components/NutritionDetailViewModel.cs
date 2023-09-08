using CommunityToolkit.Mvvm.ComponentModel;
using NutritionApp.MVVM.ViewModels;
using NutritionApp.Services;

namespace NutritionApp.MVVM.Viewmodels;

public partial class NutritionDetailViewModel : BaseViewModel
{
    private readonly INutritionTracker nutritionTracker;

    [ObservableProperty]
    public double kcal;

    [ObservableProperty]
    public double protein;

    [ObservableProperty]
    public double carbs;

    [ObservableProperty]
    public double fat;

    public NutritionDetailViewModel(INutritionTracker nutritionTracker)
    {
        this.nutritionTracker = nutritionTracker;

        nutritionTracker.ItemAdded += (sender, args) =>
        {
            Kcal = nutritionTracker.TotalKcal;
            Protein = nutritionTracker.TotalProtein;
            Carbs = nutritionTracker.TotalCarbs;
            Fat = nutritionTracker.TotalFat;
        };
    }
}
