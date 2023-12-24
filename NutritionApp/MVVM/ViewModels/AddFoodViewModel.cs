using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Nutrition.Core;
using NutritionApp.Data;
using NutritionApp.MVVM.Viewmodels.Utils;
using NutritionApp.MVVM.Views;
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
    private readonly NavigationService navigationService;

    [ObservableProperty]
    private string mealOfDayString;

    public ObservableCollection<FoodItem> SearchResults { get; } = new();

    public AddFoodViewModel(INutritionService nutritionService, IDataRepository dataRepository, IToastService toastService, NavigationService navigationService)
    {
        this.nutritionService = nutritionService;
        this.dataRepository = dataRepository;
        this.toastService = toastService;
        this.navigationService = navigationService;

        Initialize();
    }

    public void Initialize()
    {
        LoadFrequentlyUsedFoodItems();
    }

    private void LoadFrequentlyUsedFoodItems()
    {
        var foodItems = dataRepository.GetRecentFoodItems();
        SearchResults.AddRange(foodItems);
    }

    public void SearchRecent(string query)
    {
        var foodItems = dataRepository.SearchRecentFoodItems(query);
        SearchResults.AddRange(foodItems);
    }

    [RelayCommand]
    public async Task PerformSearch(string query)
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
                    foodItem.MealOfDay = Enum.TryParse(MealOfDayString?.ToString(), out MealOfDay meal) ? meal : MealOfDay.NoClassification;
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
    public async Task SelectFood(FoodItem selectedFoodItem)
    {
        if (selectedFoodItem != null)
            await navigationService.NavigateToFoodDetailPage(selectedFoodItem);
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