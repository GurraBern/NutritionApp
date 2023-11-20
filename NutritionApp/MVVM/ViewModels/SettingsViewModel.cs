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
    private readonly ISettingsService settingsService;

    public ObservableCollection<Nutrient> NutritionSettings { get; } = new();

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
    private void UseDefaultNutrientNeeds()
    {
        NutritionSettings.Clear();

        var defaultNutrients = settingsService.GetAllNutrientNeeds();
        NutritionSettings.AddRange(defaultNutrients);

        var serializedNutrients = JsonConvert.SerializeObject(NutritionSettings);
        Preferences.Set(NutrientsKey, serializedNutrients);
    }
}
