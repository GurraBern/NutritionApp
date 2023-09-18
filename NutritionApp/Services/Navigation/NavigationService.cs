using NutritionApp.MVVM.Models;
using NutritionApp.MVVM.ViewModels;
using NutritionApp.MVVM.Views;
using NutritionApp.Services.NutritionServices.NutritionTrackingService;

namespace NutritionApp.Services;

public class NavigationService
{
    private readonly INutritionTracker nutritionTracker;

    public NavigationService(INutritionTracker nutritionTracker)
    {
        this.nutritionTracker = nutritionTracker;
    }
    public async Task NavigateToFoodDetailPage(FoodItem foodItem)
    {
        var foodDetailViewModel = new FoodDetailViewModel(foodItem, nutritionTracker);
        var foodDetailPage = new FoodDetailPage(foodDetailViewModel);
        await Shell.Current.Navigation.PushAsync(foodDetailPage);
    }
}
