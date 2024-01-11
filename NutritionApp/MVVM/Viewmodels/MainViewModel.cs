using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Nutrition.Core;
using NutritionApp.MVVM.Models;
using NutritionApp.Services;
using NutritionApp.Services.NutritionServices;
using System.Collections.ObjectModel;

namespace NutritionApp.MVVM.ViewModels;

public partial class MainViewModel : BaseViewModel, IAsyncInitialization, IRecipient<FoodItem>
{
    private readonly INutritionTracker nutritionTracker;

    [ObservableProperty]
    private NutritionDay selectedNutritionDay;

    public ObservableCollection<FoodItem> SearchResults { get; } = [];
    public ObservableCollection<FoodItem> BreakfastFoods { get; } = [];
    public ObservableCollection<FoodItem> LunchFoods { get; } = [];
    public ObservableCollection<FoodItem> DinnerFoods { get; } = [];
    public ObservableCollection<FoodItem> SnacksFoods { get; } = [];
    public NutrientModel Protein { get; }
    public NutrientModel Carbohydrates { get; }
    public NutrientModel Fat { get; }
    public NutrientModel Calories { get; }

    public NavigationService NavigationService { get; }
    public Task Initialization { get; private set; }

    public MainViewModel(INutritionTracker nutritionTracker, INutrientFactory nutrientFactory, NavigationService navigationService)
    {
        this.nutritionTracker = nutritionTracker;
        this.NavigationService = navigationService;
        Protein = nutrientFactory.CreateNutrient("Protein");
        Carbohydrates = nutrientFactory.CreateNutrient("Carbohydrates");
        Carbohydrates.CustomName = "Carbs";
        Fat = nutrientFactory.CreateNutrient("Fat");
        Calories = nutrientFactory.CreateNutrient("Calories");

        Initialization = InitializeAsync();

        WeakReferenceMessenger.Default.Register(this);
    }

    private async Task InitializeAsync()
    {
        await AssignNutritionDay();
        UpdateNutritionInformation();
        ClearSearchResults();
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
    public async Task AddFood(MealOfDay mealOfDay)
    {
        await NavigationService.NavigateToAddFoodPage(mealOfDay);
    }

    public void Receive(FoodItem message)
    {
        UpdateNutritionInformation();
    }
}