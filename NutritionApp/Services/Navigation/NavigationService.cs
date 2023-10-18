using Nutrition.Core;
using NutritionApp.MVVM.Models;
using NutritionApp.MVVM.ViewModels;
using NutritionApp.MVVM.Views;
using NutritionApp.Services.NutritionServices;

namespace NutritionApp.Services;

public class NavigationService
{
    private readonly INutritionTracker nutritionTracker;
    private readonly INutrientFactory nutrientFactory;

    public NavigationService(INutritionTracker nutritionTracker, INutrientFactory nutrientFactory)
    {
        this.nutritionTracker = nutritionTracker;
        this.nutrientFactory = nutrientFactory;
    }

    public async Task NavigateToFoodDetailPage(FoodItem foodItem)
    {
        var foodDetailViewModel = new FoodDetailViewModel(foodItem, nutritionTracker, nutrientFactory);
        var foodDetailPage = new FoodDetailPage(foodDetailViewModel);
        await Shell.Current.Navigation.PushAsync(foodDetailPage);
    }
}
