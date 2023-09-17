using CommunityToolkit.Mvvm.Input;
using NutritionApp.MVVM.Models;
using NutritionApp.Services.NutritionServices.NutritionService;
using NutritionApp.Services.NutritionServices.NutritionTrackingService;
using System.Collections.ObjectModel;

namespace NutritionApp.MVVM.ViewModels;

public partial class MainViewModel : BaseViewModel
{
    private readonly INutritionService nutritionService;
    private readonly INutritionTracker nutritionTracker;

    public ObservableCollection<FoodItem> SearchResults { get; set; } = new();
    public ObservableCollection<FoodItem> ConsumedFoodItems { get; set; } = new();

    public MainViewModel(INutritionService nutritionService, INutritionTracker nutritionTracker)
    {
        this.nutritionService = nutritionService;
        this.nutritionTracker = nutritionTracker;
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

    public void UpdateConsumedFoodItems()
    {
        ConsumedFoodItems.Clear();

        var consumedFoodItems = nutritionTracker.ConsumedFoods;
        foreach (var foodItem in consumedFoodItems)
        {
            ConsumedFoodItems.Add(foodItem);
        }
    }

    [RelayCommand]
    public void ClearSearchResults()
    {
        SearchResults.Clear();
    }
}
