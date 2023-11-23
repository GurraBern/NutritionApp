using CommunityToolkit.Mvvm.Input;
using Newtonsoft.Json;
using Nutrition.Core;
using NutritionApp.MVVM.Models;
using NutritionApp.MVVM.Viewmodels.Utils;
using NutritionApp.Services.NutritionServices;
using System.Collections.ObjectModel;

namespace NutritionApp.MVVM.ViewModels;

public partial class SettingsViewModel : BaseViewModel
{
    private const string NutrientsKey = "NutrientsSettings";
    private readonly ISettingsService settingsService;
    public ObservableCollection<Nutrient> NutritionSettings { get; } = [];
    public TimePeriod BreakfastTimePeriod { get; set; }
    public TimePeriod LunchTimePeriod { get; set; }
    public TimePeriod DinnerTimePeriod { get; set; }

    public SettingsViewModel(ISettingsService settingsService)
    {
        this.settingsService = settingsService;

        LoadNutrients();
        LoadMealTimeslots();
    }

    private void LoadNutrients()
    {
        var storedNutrients = Preferences.Get(NutrientsKey, "");

        if (!string.IsNullOrEmpty(storedNutrients))
        {
            var nutrients = JsonConvert.DeserializeObject<ObservableCollection<Nutrient>>(storedNutrients);
            NutritionSettings.AddRange(nutrients);
        }
        else
        {
            var defaultNutrients = settingsService.GetAllNutrientNeeds();
            NutritionSettings.AddRange(defaultNutrients);
        }
    }

    private void LoadMealTimeslots()
    {
        BreakfastTimePeriod = settingsService.GetMealPeriod(MealOfDay.Breakfast);
        LunchTimePeriod = settingsService.GetMealPeriod(MealOfDay.Lunch);
        DinnerTimePeriod = settingsService.GetMealPeriod(MealOfDay.Dinner);
    }

    [RelayCommand]
    private void SaveNutrients()
    {
        var serializedNutrients = JsonConvert.SerializeObject(NutritionSettings);
        Preferences.Set(NutrientsKey, serializedNutrients);
    }

    [RelayCommand]
    private void SaveMealTimeslots()
    {
        var breakfastTimeslots = JsonConvert.SerializeObject(BreakfastTimePeriod);
        Preferences.Set(MealOfDay.Breakfast.ToString(), breakfastTimeslots);

        var lunchTimeslots = JsonConvert.SerializeObject(LunchTimePeriod);
        Preferences.Set(MealOfDay.Lunch.ToString(), lunchTimeslots);

        var dinnerTimeslots = JsonConvert.SerializeObject(DinnerTimePeriod);
        Preferences.Set(MealOfDay.Dinner.ToString(), dinnerTimeslots);
    }

    [RelayCommand]
    private void UseDefaultNutrientNeeds()
    {
        NutritionSettings.Clear();

        var defaultNutrients = settingsService.GetAllNutrientNeeds();
        NutritionSettings.AddRange(defaultNutrients);

        var serializedNutrients = JsonConvert.SerializeObject(NutritionSettings);
        Preferences.Set(NutrientsKey, serializedNutrients);
    }
}