using CommunityToolkit.Mvvm.Input;
using Nutrition.Core;
using NutritionApp.MVVM.Views;
using NutritionApp.Services.NutritionServices;
using System.Collections.ObjectModel;

namespace NutritionApp.MVVM.ViewModels;

public partial class AddFoodViewModel : BaseViewModel
{
    private readonly INutritionService nutritionService;

    public ObservableCollection<FoodItem> SearchResults { get; } = new();

    public AddFoodViewModel(INutritionService nutritionService)
    {
        this.nutritionService = nutritionService;
    }

    [RelayCommand]
    public async Task PerformSearch(string query)
    {
        if (string.IsNullOrEmpty(query))
            return;

        IsBusy = true;

        var searchResult = await nutritionService.GetSearchResults(query);
        if (searchResult != null)
        {
            SearchResults.Clear();
            foreach (var foodItem in searchResult)
            {
                SearchResults.Add(foodItem);
            }
        }

        IsBusy = false;
    }

    [RelayCommand]
    public void ClearSearchResults()
    {
        SearchResults.Clear();
    }

    [RelayCommand]
    public static async Task GoBack()
    {
        await Shell.Current.GoToAsync(nameof(MainPage));
    }
}
