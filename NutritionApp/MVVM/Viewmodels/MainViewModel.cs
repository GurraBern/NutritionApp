using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using NutritionApp.MVVM.Models;
using NutritionApp.MVVM.Viewmodels.Utils;
using NutritionApp.Services.NutritionServices;
using System.Collections.ObjectModel;

namespace NutritionApp.MVVM.ViewModels;

public partial class MainViewModel : BaseViewModel
{
    private readonly INutritionService nutritionService;
    private readonly INutritionTracker nutritionTracker;
    private readonly INutrientFactory nutritionFactory;
    [ObservableProperty]
    private NutritionDay selectedNutritionDay;
    public ObservableCollection<FoodItem> SearchResults { get; } = new();
    public ObservableCollection<NutritionDay> nutritionDays = new();
    public ObservableCollection<FoodItem> ConsumedFoodItems { get; } = new();
    public ObservableCollection<Nutrient> PrimaryNutrients { get; } = new();
    public ObservableCollection<Nutrient> Vitamins { get; } = new();
    public ObservableCollection<Nutrient> Minerals { get; } = new();
    public ObservableCollection<Nutrient> AminoAcids { get; } = new();

    public MainViewModel(INutritionService nutritionService, INutritionTracker nutritionTracker, INutrientFactory nutritionFactory)
    {
        this.nutritionService = nutritionService;
        this.nutritionTracker = nutritionTracker;
        this.nutritionFactory = nutritionFactory;

        SetupNutrients(NutritionUtils.mainNutrients, PrimaryNutrients);
        SetupNutrients(NutritionUtils.vitamins, Vitamins);
        SetupNutrients(NutritionUtils.minerals, Minerals);
        SetupNutrients(NutritionUtils.aminoAcids, AminoAcids);
    }

    public async Task AssignNutritionDay()
    {
        SelectedNutritionDay = await nutritionTracker.GetSelectedNutritionDay();
        UpdateNutritionInformation();
    }

    public void UpdateNutritionInformation()
    {
        ConsumedFoodItems.Clear();
        foreach (var food in SelectedNutritionDay.ConsumedFoodItems)
        {
            ConsumedFoodItems.Add(food);
        }

        foreach (var nutrient in PrimaryNutrients.Concat(Vitamins).Concat(Minerals).Concat(AminoAcids))
        {
            nutrient.SetProgress(nutrient.NutritionAmount, SelectedNutritionDay.NutrientTotals[nutrient.Name]);
        }
    }

    private void SetupNutrients(List<string> nutrientNames, ObservableCollection<Nutrient> nutrientCollection)
    {
        foreach (var name in nutrientNames)
        {
            var nutrient = nutritionFactory.CreateNutrient(name);
            nutrientCollection.Add(nutrient);
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
    public void PreviousDay()
    {
        SelectedNutritionDay = nutritionTracker.PreviousDay();
        UpdateNutritionInformation();
    }
}
