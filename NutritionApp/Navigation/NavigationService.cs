using CommunityToolkit.Mvvm.Input;
using Nutrition.Core;
using NutritionApp.Data.Services;
using NutritionApp.MVVM.Models;
using NutritionApp.MVVM.ViewModels;
using NutritionApp.MVVM.Views;

namespace NutritionApp.Services;

public partial class NavigationService(INutritionTracker nutritionTracker, INutrientFactory nutrientFactory)
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

    [RelayCommand]
    public async Task NavigateToNutritionDetails()
    {
        await Shell.Current.GoToAsync($"//{nameof(NutritionDetailPage)}");
    }

    [RelayCommand]
    public async Task NavigateToAddFoodPage(MealOfDay mealOfDay)
    {
        await Shell.Current.GoToAsync($"//{nameof(AddFoodPage)}?MealOfDayString={mealOfDay}");
    }

    [RelayCommand]
    public async Task NavigateToMealDetails()
    {
        await Shell.Current.GoToAsync($"{nameof(MealDetailView)}");
    }

    [RelayCommand]
    public async Task NavigateToSettings()
    {
        await Shell.Current.GoToAsync($"//{nameof(SettingsPage)}");
    }

    [RelayCommand]
    public async Task NavigateToDashboard()
    {
        await Shell.Current.GoToAsync($"//{nameof(MainPage)}");
    }

    [RelayCommand]
    public async Task NavigateToUserPages()
    {
        await Shell.Current.GoToAsync($"//{nameof(UserPage)}");
    }

    [RelayCommand]
    public async Task NavigateToAddWeightPage()
    {
        await Shell.Current.GoToAsync($"//{nameof(AddWeightPage)}");
    }
}

public enum PageMode
{
    Add,
    Edit
}