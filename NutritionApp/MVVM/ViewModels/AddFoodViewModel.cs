using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Nutrition.Core;
using NutritionApp.Data;
using NutritionApp.MVVM.Viewmodels.Utils;
using NutritionApp.Services;
using NutritionApp.Services.NutritionServices;
using System.Collections.ObjectModel;

namespace NutritionApp.MVVM.ViewModels;

[QueryProperty(nameof(MealOfDayString), nameof(MealOfDayString))]
public partial class AddFoodViewModel : BaseViewModel
{
    private readonly INutritionService nutritionService;
    private readonly IDataRepository dataRepository;
    private readonly IToastService toastService;

    [ObservableProperty]
    private string mealOfDayString;

    public ObservableCollection<FoodItem> SearchResults { get; } = [];
    public NavigationService NavigationService { get; }

    public AddFoodViewModel(INutritionService nutritionService, IDataRepository dataRepository, IToastService toastService, NavigationService navigationService)
    {
        this.nutritionService = nutritionService;
        this.dataRepository = dataRepository;
        this.toastService = toastService;
        this.NavigationService = navigationService;

        Initialize();
    }

    public void Initialize()
    {
        LoadFrequentlyUsedFoodItems();
    }

    private void LoadFrequentlyUsedFoodItems()
    {
        var foodItems = dataRepository.GetRecentFoodItems();

        if (!foodItems.Equals(SearchResults))
            SearchResults.AddRange(foodItems);
    }

    public void SearchRecent(string query)
    {
        var foodItems = dataRepository.SearchRecentFoodItems(query);
        SearchResults.AddRange(foodItems);
    }

    [RelayCommand]
    private async Task PerformSearch(string query)
    {
        if (string.IsNullOrEmpty(query))
            return;

        IsBusy = true;
        try
        {
            var searchResult = await nutritionService.GetSearchResults(query);
            if (searchResult != null)
            {
                SearchResults.Clear();
                foreach (var foodItem in searchResult)
                {
                    SearchResults.Add(foodItem);
                }
            }
        }
        catch (Exception)
        {
            await toastService.MakeToast("Service is not available");
        }

        IsBusy = false;
    }

    [RelayCommand]
    private async Task SelectFood(FoodItem selectedFoodItem)
    {
        selectedFoodItem.MealOfDay = Enum.TryParse(MealOfDayString?.ToString(), out MealOfDay meal) ? meal : MealOfDay.NoClassification;

        if (selectedFoodItem != null)
            await NavigationService.NavigateToFoodDetailPage(selectedFoodItem, PageMode.Add);
    }

    public void ClearSearchResults()
    {
        SearchResults.Clear();
    }
}