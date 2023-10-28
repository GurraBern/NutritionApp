using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Nutrition.Core;
using NutritionApp.MVVM.Models;
using NutritionApp.Services.NutritionServices;
using System.Collections.ObjectModel;

namespace NutritionApp.MVVM.ViewModels;

public partial class MainViewModel : BaseViewModel
{
    private readonly INutritionService nutritionService;
    private readonly INutritionTracker nutritionTracker;
    private readonly INutrientFactory nutrientFactory;
    [ObservableProperty]
    private NutritionDay selectedNutritionDay;
    public ObservableCollection<FoodItem> SearchResults { get; } = new();
    public ObservableCollection<NutritionDay> nutritionDays = new();
    public ObservableCollection<FoodItem> ConsumedFoodItems { get; } = new();

    public Nutrient Protein { get; }
    public Nutrient Carbohydrates { get; }
    public Nutrient Fat { get; }


    public MainViewModel(INutritionService nutritionService, INutritionTracker nutritionTracker, INutrientFactory nutrientFactory)
    {
        this.nutritionService = nutritionService;
        this.nutritionTracker = nutritionTracker;
        this.nutrientFactory = nutrientFactory;

        Protein = nutrientFactory.CreateNutrient("Protein");
        Carbohydrates = nutrientFactory.CreateNutrient("Carbohydrates");
        Carbohydrates.CustomName = "Carbs";
        Fat = nutrientFactory.CreateNutrient("Fat");
    }

    public async Task AssignNutritionDay()
    {
        IsBusy = true;

        SelectedNutritionDay = await nutritionTracker.GetSelectedNutritionDay();
        UpdateNutritionInformation();

        IsBusy = false;
    }

    public void UpdateNutritionInformation()
    {
        ConsumedFoodItems.Clear();
        foreach (var food in SelectedNutritionDay.ConsumedFoodItems)
        {
            ConsumedFoodItems.Add(food);
        }

        Protein.SetProgress(SelectedNutritionDay.NutrientTotals[Protein.Name], SelectedNutritionDay.NutrientTotals[Protein.Name]);
        Carbohydrates.SetProgress(SelectedNutritionDay.NutrientTotals[Carbohydrates.Name], SelectedNutritionDay.NutrientTotals[Carbohydrates.Name]);
        Fat.SetProgress(SelectedNutritionDay.NutrientTotals[Fat.Name], SelectedNutritionDay.NutrientTotals[Fat.Name]);
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
    public void NextDay()
    {
        SelectedNutritionDay = nutritionTracker.NextDay();
        UpdateNutritionInformation();
    }

    [RelayCommand]
    public async Task PreviousDay()
    {
        SelectedNutritionDay = await nutritionTracker.PreviousDay();
        UpdateNutritionInformation();
    }
}
