using Nutrition.Core;
using NutritionApp.MVVM.Models;
using NutritionApp.MVVM.ViewModels;
using NutritionApp.MVVM.Views;
using NutritionApp.Services.NutritionServices;

namespace NutritionApp.Services;

public class NavigationService(INutritionTracker nutritionTracker, INutrientFactory nutrientFactory)
{
    public async Task NavigateToFoodDetailPage(FoodItem foodItem)
    {
        var foodDetailViewModel = new FoodDetailViewModel(foodItem, nutritionTracker, nutrientFactory);
        var foodDetailPage = new FoodDetailPage(foodDetailViewModel);
        await Shell.Current.Navigation.PushAsync(foodDetailPage);
    }

    public async Task NavigateToNutritionDetails()
    {
        await Shell.Current.GoToAsync($"//{nameof(NutritionDetailPage)}");
    }

    public async Task NavigateToAddFoodPage(MealOfDay mealOfDay)
    {
        await Shell.Current.GoToAsync($"//{nameof(AddFoodPage)}?MealOfDayString={mealOfDay}");
    }
}
