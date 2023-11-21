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
    public TimePeriod BreakfastTimeslots { get; set; } = new TimePeriod(TimeSpan.FromHours(6), TimeSpan.FromHours(10));
    public TimePeriod LunchTimeslots { get; set; } = new TimePeriod(TimeSpan.FromHours(11), TimeSpan.FromHours(14));
    public TimePeriod DinnerTimeslots { get; set; } = new TimePeriod(TimeSpan.FromHours(17), TimeSpan.FromHours(20));

    public SettingsViewModel(ISettingsService settingsService)
    {
        this.settingsService = settingsService;

        LoadNutrients();
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

    [RelayCommand]
    private void SaveNutrients()
    {
        var serializedNutrients = JsonConvert.SerializeObject(NutritionSettings);
        Preferences.Set(NutrientsKey, serializedNutrients);
    }

    [RelayCommand]
    private void SaveMealTimeslots()
    {
        var breakfastTimeslots = JsonConvert.SerializeObject(BreakfastTimeslots);
        var lunchTimeslots = JsonConvert.SerializeObject(LunchTimeslots);
        var dinnerTimeslots = JsonConvert.SerializeObject(DinnerTimeslots);

        Preferences.Set(BreakfastKey, breakfastTimeslots);
        Preferences.Set(LunchKey, lunchTimeslots);
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

    public struct TimePeriod(TimeSpan startTime, TimeSpan endTime)
    {
        public TimeSpan StartTime { get; set; } = startTime;
        public TimeSpan EndTime { get; set; } = endTime;
    }
}