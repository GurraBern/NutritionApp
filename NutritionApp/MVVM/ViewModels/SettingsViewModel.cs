using CommunityToolkit.Mvvm.Input;
using Newtonsoft.Json;
using Nutrition.Core;
using System.Collections.ObjectModel;

namespace NutritionApp.MVVM.ViewModels;

public partial class SettingsViewModel : BaseViewModel
{
    private const string NutrientsKey = "NutrientsSettings";

    public ObservableCollection<Nutrient> NutritionSettings { get; } = new ObservableCollection<Nutrient>();

    public SettingsViewModel()
    {
        LoadNutrients();
    }

    public void AddOrUpdateNutrient(Nutrient nutrient)
    {
        var existingNutrient = NutritionSettings.FirstOrDefault(n => n.NutrientName == nutrient.NutrientName);

        if (existingNutrient != null)
        {
            existingNutrient.Amount = nutrient.Amount;
        }
        else
        {
            NutritionSettings.Add(nutrient);
        }

        SaveNutrients();
    }

    private async Task LoadNutrients()
    {
        var settings = await SecureStorage.GetAsync(NutrientsKey);
        if (settings != null)
        {
            var nutritionSettings = JsonConvert.DeserializeObject<ObservableCollection<Nutrient>>(settings);
        }
    }

    [RelayCommand]
    private async Task SaveNutrients()
    {
        var serializedNutrients = JsonConvert.SerializeObject(NutritionSettings);
        await SecureStorage.SetAsync(NutrientsKey, serializedNutrients);
    }
}
