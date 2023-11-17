using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Nutrition.Core;
using NutritionApp.MVVM.Models;
using NutritionApp.Services;
using NutritionApp.Services.NutritionServices;
using System.Collections.ObjectModel;

namespace NutritionApp.MVVM.ViewModels;

public partial class MainViewModel : BaseViewModel
{
    private readonly INutritionTracker nutritionTracker;
    private readonly NavigationService navigationService;
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
    public Nutrient Calories { get; }

    public MainViewModel(INutritionTracker nutritionTracker, INutrientFactory nutrientFactory, NavigationService navigationService)
    {
        this.nutritionTracker = nutritionTracker;
        this.navigationService = navigationService;
        Protein = nutrientFactory.CreateNutrient("Protein");
        Carbohydrates = nutrientFactory.CreateNutrient("Carbohydrates");
        Carbohydrates.CustomName = "Carbs";
        Fat = nutrientFactory.CreateNutrient("Fat");
        Calories = nutrientFactory.CreateNutrient("Calories");
        Calories.unit = string.Empty;
    }

    public async Task AssignNutritionDay()
    {
        IsBusy = true;

        SelectedNutritionDay = await nutritionTracker.GetSelectedNutritionDay();

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
        Calories.SetProgress(SelectedNutritionDay.NutrientTotals[Calories.Name], SelectedNutritionDay.NutrientTotals[Calories.Name]);
    }

    private static void ClearAndCopy(List<FoodItem> source, ObservableCollection<FoodItem> target)
    {
        target.Clear();
        foreach (var food in source)
        {
            target.Add(food);
        }
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

    [RelayCommand]
    public async Task AddFoodToBreakfast()
    {
        await navigationService.NavigateToAddFoodPage(MealOfDay.Breakfast);
    }

    [RelayCommand]
    public async Task AddFoodToLunch()
    {
        await navigationService.NavigateToAddFoodPage(MealOfDay.Lunch);
    }

    [RelayCommand]
    public async Task AddFoodToDinner()
    {
        await navigationService.NavigateToAddFoodPage(MealOfDay.Dinner);
    }

    [RelayCommand]
    public async Task AddFoodToSnacks()
    {
        await navigationService.NavigateToAddFoodPage(MealOfDay.Snacks);
    }

    [RelayCommand]
    public async Task NavigateToNutritionDetails()
    {
        await navigationService.NavigateToNutritionDetails();
    }
}
