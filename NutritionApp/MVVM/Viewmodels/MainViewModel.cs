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
    private readonly ISettingsService settingsService;
    private int dayIndex = 0;
    public ObservableCollection<FoodItem> SearchResults { get; set; } = new();
    public ObservableCollection<NutritionDay> nutritionDays = new();

    [ObservableProperty]
    public NutritionDay selectedDailyFood;
    public ObservableCollection<FoodItem> ConsumedFoodItems { get; set; } = new();

    public ObservableCollection<Nutrient> PrimaryNutrients { get; set; } = new();
    public ObservableCollection<Nutrient> Vitamins { get; set; } = new();
    public ObservableCollection<Nutrient> Minerals { get; set; } = new();
    public ObservableCollection<Nutrient> AminoAcids { get; set; } = new();


    public MainViewModel(INutritionService nutritionService, INutritionTracker nutritionTracker, ISettingsService settingsService)
    {
        this.nutritionService = nutritionService;
        this.nutritionTracker = nutritionTracker;
        this.settingsService = settingsService;
        selectedDailyFood = new NutritionDay(DateTime.Today);
        nutritionTracker.NutritionDay = selectedDailyFood;

        nutritionDays.Add(selectedDailyFood);
        nutritionDays.Add(new NutritionDay(DateTime.Today.AddDays(-1)));
    }

    public void UpdateNutritionInformation()
    {
        ConsumedFoodItems.Clear();
        foreach (var food in SelectedDailyFood.ConsumedFoodItems)
        {
            ConsumedFoodItems.Add(food);
        }

        PrimaryNutrients.Clear();
        Vitamins.Clear();
        Minerals.Clear();
        AminoAcids.Clear();
        CreateAndAddNutrients(NutritionUtils.mainNutrients, PrimaryNutrients);
        CreateAndAddNutrients(NutritionUtils.vitamins, Vitamins);
        CreateAndAddNutrients(NutritionUtils.minerals, Minerals);
        CreateAndAddNutrients(NutritionUtils.aminoAcids, AminoAcids);
    }

    private void CreateAndAddNutrients(List<string> nutrientNames, ObservableCollection<Nutrient> nutrientCollection)
    {
        foreach (var valuePair in nutritionTracker.NutritionDay.NutrientTotals.Where(x => nutrientNames.Contains(x.Key)))
        {
            nutrientCollection.Add(new Nutrient(valuePair.Key, valuePair.Value, 1, settingsService, nutritionTracker.NutritionDay));
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
        dayIndex--;
        if (dayIndex < 0)
        {
            dayIndex = 0;

            SelectedDailyFood = nutritionDays[dayIndex];
            nutritionTracker.NutritionDay = SelectedDailyFood;
        }

        UpdateNutritionInformation();
    }

    [RelayCommand]
    public void PreviousDay()
    {
        dayIndex++;
        if (dayIndex >= nutritionDays.Count)
            dayIndex = 0;

        SelectedDailyFood = nutritionDays[dayIndex];
        nutritionTracker.NutritionDay = SelectedDailyFood;

        UpdateNutritionInformation();
    }
}
