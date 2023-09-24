using CommunityToolkit.Mvvm.ComponentModel;
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
    private readonly ISettingsService settingsService;

    public ObservableCollection<FoodItem> SearchResults { get; set; } = new();
    public ObservableCollection<NutritionDay> nutritionDays = new();

    [ObservableProperty]
    public NutritionDay selectedDailyFood;
    public ObservableCollection<FoodItem> ConsumedFoodItems { get; set; } = new();

    public ObservableCollection<Nutrient> PrimaryNutrients { get; set; } = new();


    public MainViewModel(INutritionService nutritionService, INutritionTracker nutritionTracker, ISettingsService settingsService)
    {
        this.nutritionService = nutritionService;
        this.nutritionTracker = nutritionTracker;
        this.settingsService = settingsService;
        selectedDailyFood = new NutritionDay(DateTime.Today);
        nutritionTracker.NutritionDay = selectedDailyFood;
    }

    public void UpdateNutritionInformation()
    {
        ConsumedFoodItems.Clear();
        PrimaryNutrients.Clear();
        foreach (var item in nutritionTracker.NutritionDay.ConsumedFoodItems)
        {
            ConsumedFoodItems.Add(item);
        }

        foreach (var valuePair in nutritionTracker.NutritionDay.NutrientTotals)
        {
            Nutrient nutrient = new(valuePair.Key, valuePair.Value, 1, settingsService, nutritionTracker.NutritionDay);
            PrimaryNutrients.Add(nutrient);
        }
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
}
