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
    [ObservableProperty]
    private NutritionDay selectedNutritionDay;
    public ObservableCollection<FoodItem> SearchResults { get; } = new();
    public ObservableCollection<FoodItem> BreakfastFoods { get; } = new();
    public ObservableCollection<FoodItem> LunchFoods { get; } = new();
    public ObservableCollection<FoodItem> DinnerFoods { get; } = new();
    public ObservableCollection<FoodItem> SnacksFoods { get; } = new();
    public Nutrient Protein { get; }
    public Nutrient Carbohydrates { get; }
    public Nutrient Fat { get; }


    public MainViewModel(INutritionService nutritionService, INutritionTracker nutritionTracker, INutrientFactory nutrientFactory)
    {
        this.nutritionService = nutritionService;
        this.nutritionTracker = nutritionTracker;

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
        ClearAndCopy(SelectedNutritionDay.BreakfastFoods, BreakfastFoods);
        ClearAndCopy(SelectedNutritionDay.LunchFoods, LunchFoods);
        ClearAndCopy(SelectedNutritionDay.DinnerFoods, DinnerFoods);
        ClearAndCopy(SelectedNutritionDay.SnacksFoods, SnacksFoods);

        Protein.SetProgress(SelectedNutritionDay.NutrientTotals[Protein.Name], SelectedNutritionDay.NutrientTotals[Protein.Name]);
        Carbohydrates.SetProgress(SelectedNutritionDay.NutrientTotals[Carbohydrates.Name], SelectedNutritionDay.NutrientTotals[Carbohydrates.Name]);
        Fat.SetProgress(SelectedNutritionDay.NutrientTotals[Fat.Name], SelectedNutritionDay.NutrientTotals[Fat.Name]);
    }

    private void ClearAndCopy(List<FoodItem> source, ObservableCollection<FoodItem> target)
    {
        target.Clear();
        foreach (var food in source)
        {
            target.Add(food);
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
