using CommunityToolkit.Mvvm.Input;
using NutritionApp.MVVM.Models;
using NutritionApp.MVVM.ViewModels;
using NutritionApp.Services;
using System.Collections.ObjectModel;

namespace NutritionApp.MVVM.Viewmodels;

public partial class MainViewModel : BaseViewModel
{
    private readonly INutritionService nutritionService;
    private readonly INutritionTracker nutritionTracker;

    public ObservableCollection<FoodItem> SearchResults { get; set; } = new();
    public ObservableCollection<FoodItem> ConsumedFoodItems { get; set; } = new();
    private string searchQuery = string.Empty;

    public MainViewModel(INutritionService nutritionService, INutritionTracker nutritionTracker)
    {
        this.nutritionService = nutritionService;
        this.nutritionTracker = nutritionTracker;
    }

    [RelayCommand]
    public async Task PerformSearch(string query)
    {
        if (query.IsEqualOrEmpty(searchQuery))
            return;

        searchQuery = query;
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

    public void UpdateConsumedFoodItems()
    {
        ConsumedFoodItems.Clear();

        var consumedFoodItems = nutritionTracker.ConsumedFoods;
        foreach (var foodItem in consumedFoodItems)
        {
            ConsumedFoodItems.Add(foodItem);
        }
    }
}
