using CommunityToolkit.Mvvm.Input;
using Nutrition.Core;
using NutritionApp.MVVM.Models;
using NutritionApp.MVVM.Viewmodels.Utils;
using NutritionApp.MVVM.Views;
using NutritionApp.Services.NutritionServices;
using System.Collections.ObjectModel;

namespace NutritionApp.MVVM.ViewModels;

public partial class NutritionDetailViewModel : BaseViewModel
{
    private readonly INutritionTracker nutritionTracker;
    private readonly INutrientFactory nutrientFactory;
    private NutritionDay nutritionDay;
    public ObservableCollection<Nutrient> PrimaryNutrients { get; } = new();
    public ObservableCollection<Nutrient> Fats { get; } = new();
    public ObservableCollection<Nutrient> Vitamins { get; } = new();
    public ObservableCollection<Nutrient> MacroMinerals { get; } = new();
    public ObservableCollection<Nutrient> AminoAcids { get; } = new();
    public NutritionDetailViewModel(INutritionTracker nutritionTracker, INutrientFactory nutrientFactory)
    {
        this.nutritionTracker = nutritionTracker;
        this.nutrientFactory = nutrientFactory;
        SetupNutrients(NutritionUtils.mainNutrients, PrimaryNutrients);
        SetupNutrients(NutritionUtils.fats, Fats);
        SetupNutrients(NutritionUtils.vitamins, Vitamins);
        SetupNutrients(NutritionUtils.macroMinerals, MacroMinerals);
        //SetupNutrients(NutritionUtils.aminoAcids, AminoAcids);
    }

    private void SetupNutrients(List<string> nutrientNames, ObservableCollection<Nutrient> nutrientCollection)
    {
        foreach (var name in nutrientNames)
        {
            var nutrient = nutrientFactory.CreateNutrient(name);
            nutrientCollection.Add(nutrient);
        }
    }

    public async Task UpdateNutritionInformation()
    {
        nutritionDay = await nutritionTracker.GetSelectedNutritionDay();

        foreach (var nutrient in PrimaryNutrients.Concat(Vitamins).Concat(MacroMinerals).Concat(AminoAcids))
        {
            nutrient.SetProgress(nutritionDay.NutrientTotals[nutrient.Name], nutritionDay.NutrientTotals[nutrient.Name]);
        }
    }

    [RelayCommand]
    public static async Task GoBack()
    {
        await Shell.Current.GoToAsync(nameof(MainPage));
    }
}
