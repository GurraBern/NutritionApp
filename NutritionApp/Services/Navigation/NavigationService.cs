using Nutrition.Core;
using NutritionApp.MVVM.Models;
using NutritionApp.MVVM.ViewModels;
using NutritionApp.MVVM.Views;
using NutritionApp.Services.NutritionServices;

namespace NutritionApp.Services;

public class NavigationService(INutritionTracker nutritionTracker, INutrientFactory nutrientFactory)
{
    public async Task NavigateToFoodDetailPage(FoodItem foodItem, PageMode pageMode = PageMode.Add)
    {
        var foodDetailViewModel = new FoodDetailViewModel(foodItem, nutritionTracker, nutrientFactory)
        {
            PageMode = pageMode
        };

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

    public async Task NavigateToMealDetails()
    {
        await Shell.Current.GoToAsync($"{nameof(MealDetailView)}");
    }
}

public enum PageMode
{
    Add,
    Edit
}