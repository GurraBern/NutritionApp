using NutritionApp.MVVM.Models;
using NutritionApp.MVVM.ViewModels;
using NutritionApp.MVVM.Views;
using NutritionApp.Services.NutritionServices;

namespace NutritionApp.Services;

public class NavigationService
{
    private readonly INutritionTracker nutritionTracker;
    private readonly ISettingsService settingsService;

    public NavigationService(INutritionTracker nutritionTracker, ISettingsService settingsService)
    {
        this.nutritionTracker = nutritionTracker;
        this.settingsService = settingsService;
    }

    public async Task NavigateToFoodDetailPage(FoodItem foodItem)
    {
        var foodDetailViewModel = new FoodDetailViewModel(foodItem, nutritionTracker, settingsService);
        var foodDetailPage = new FoodDetailPage(foodDetailViewModel);
        await Shell.Current.Navigation.PushAsync(foodDetailPage);
    }
}
