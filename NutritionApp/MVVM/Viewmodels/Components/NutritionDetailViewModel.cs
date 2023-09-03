using CommunityToolkit.Mvvm.ComponentModel;
using NutritionApp.MVVM.ViewModels;
using NutritionApp.Services;

namespace NutritionApp.MVVM.Viewmodels;

public partial class NutritionDetailViewModel: BaseViewModel
{
    private readonly INutritionTracker nutritionTracker;

    [ObservableProperty]
    public int kcal;

    public NutritionDetailViewModel(INutritionTracker nutritionTracker)
    {
        this.nutritionTracker = nutritionTracker;

        nutritionTracker.ItemAdded += (sender, args) =>
        {
            Kcal = nutritionTracker.TotalKcal;
        };
    }
}
