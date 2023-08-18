using NutritionApp.MVVM.Models;
using NutritionApp.MVVM.Viewmodels;
using NutritionApp.MVVM.Views;

namespace NutritionApp.Services;

public class NavigationService
{
    public static async Task NavigateToFoodDetailPage(FoodItem foodItem)
    {
        var foodDetailViewModel = new FoodDetailViewModel(foodItem);
        var foodDetailPage = new FoodDetailPage(foodDetailViewModel);
        await Shell.Current.Navigation.PushAsync(foodDetailPage);
    }
}
