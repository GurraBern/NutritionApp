using CommunityToolkit.Mvvm.Input;
using Newtonsoft.Json;
using Nutrition.Core;
using NutritionApp.MVVM.Viewmodels.Utils;
using NutritionApp.Services.NutritionServices;
using System.Collections.ObjectModel;

namespace NutritionApp.MVVM.ViewModels;

public partial class SettingsViewModel : BaseViewModel
{
    private const string NutrientsKey = "NutrientsSettings";
    private const string BreakfastKey = "BreakfastTimeslot";
    private const string LunchKey = "LunchTimeslot";
    private const string DinnerKey = "DinnerTimeslot";
    private readonly ISettingsService settingsService;
    public ObservableCollection<Nutrient> NutritionSettings { get; } = [];
    public TimePeriod BreakfastTimePeriod { get; set; } = new(TimeSpan.FromHours(6), TimeSpan.FromHours(10));
    public TimePeriod LunchTimePeriod { get; set; } = new(TimeSpan.FromHours(11), TimeSpan.FromHours(14));
    public TimePeriod DinnerTimePeriod { get; set; } = new(TimeSpan.FromHours(17), TimeSpan.FromHours(20));

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
        LoadAndSetTimePeriod(BreakfastKey, BreakfastTimePeriod);
        LoadAndSetTimePeriod(LunchKey, LunchTimePeriod);
        LoadAndSetTimePeriod(DinnerKey, DinnerTimePeriod);
    }

    private static void LoadAndSetTimePeriod(string key, TimePeriod targetTimePeriod)
    {
        var timePeriodJson = Preferences.Get(key, "");
        if (!string.IsNullOrEmpty(timePeriodJson))
        {
            var deserializedTimePeriod = JsonConvert.DeserializeObject<TimePeriod>(timePeriodJson);

            targetTimePeriod.StartTime = deserializedTimePeriod.StartTime;
            targetTimePeriod.EndTime = deserializedTimePeriod.EndTime;
        }
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
        Preferences.Set(BreakfastKey, breakfastTimeslots);

        var lunchTimeslots = JsonConvert.SerializeObject(LunchTimePeriod);
        Preferences.Set(LunchKey, lunchTimeslots);

        var dinnerTimeslots = JsonConvert.SerializeObject(DinnerTimePeriod);
        Preferences.Set(DinnerKey, dinnerTimeslots);
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

    public class TimePeriod(TimeSpan startTime, TimeSpan endTime)
    {
        public TimeSpan StartTime { get; set; } = startTime;
        public TimeSpan EndTime { get; set; } = endTime;
    }
}