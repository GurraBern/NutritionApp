using CommunityToolkit.Mvvm.Input;
using NutritionApp.MVVM.Models;
using NutritionApp.MVVM.ViewModels;
using NutritionApp.Services;
using System.Collections.ObjectModel;

namespace NutritionApp.MVVM.Viewmodels;

public partial class MainViewModel : BaseViewModel
{
    private readonly INutritionService nutritionService;
    public ObservableCollection<FoodItem> SearchResults { get; set; } = new();
    public ObservableCollection<FoodItem> BreakfastFood { get; set; } = new();
    private string searchQuery = string.Empty;

    public MainViewModel(INutritionService nutritionService)
    {
        this.nutritionService = nutritionService;
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
}
