using NutritionApp.MVVM.Models;
using NutritionApp.MVVM.ViewModels;
using NutritionApp.MVVM.Views;
using NutritionApp.Services.NutritionServices;
using NutritionApp.Services.NutritionServices.NutritionTrackingService;

namespace NutritionApp.Services;

public class NavigationService
{
    private readonly INutritionTracker nutritionTracker;
    private readonly INutrientSettings nutrientSettings;

    public NavigationService(INutritionTracker nutritionTracker, INutrientSettings nutrientSettings)
    {
        this.nutritionTracker = nutritionTracker;
        this.nutrientSettings = nutrientSettings;
    }
    public async Task NavigateToFoodDetailPage(FoodItem foodItem)
    {
        var foodDetailViewModel = new FoodDetailViewModel(foodItem, nutritionTracker, nutrientSettings);
        var foodDetailPage = new FoodDetailPage(foodDetailViewModel);
        await Shell.Current.Navigation.PushAsync(foodDetailPage);
    }
}
