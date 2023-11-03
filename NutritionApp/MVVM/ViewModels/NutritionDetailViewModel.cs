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
    public SelectionCollection SelectionCollection { get; private set; } = new();

    public NutritionDetailViewModel(INutritionTracker nutritionTracker, INutrientFactory nutrientFactory)
    {
        this.nutritionTracker = nutritionTracker;
        this.nutrientFactory = nutrientFactory;

        SetupAllNutrients();
        SetupOptions();
    }

    private void SetupOptions()
    {
        var basicOption = new OptionItem("Basic", new AsyncRelayCommand(ShowBasicNutrients));
        var advancedOption = new OptionItem("Detailed", new AsyncRelayCommand(ShowDetailedNutrients));
        SelectionCollection.Options.Add(basicOption);
        SelectionCollection.Options.Add(advancedOption);
    }

    private void SetupAllNutrients()
    {
        SetupNutrients(NutritionUtils.mainNutrients, PrimaryNutrients);
        SetupNutrients(NutritionUtils.fats, Fats);
        SetupNutrients(NutritionUtils.vitamins, Vitamins);
        SetupNutrients(NutritionUtils.macroMinerals, MacroMinerals);
        SetupNutrients(NutritionUtils.essentialAminoAcids, AminoAcids);
    }

    private void SetupNutrients(IEnumerable<string> nutrientNames, ObservableCollection<Nutrient> nutrientCollection)
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

    private static void RemoveNonMatchingNutrients(IEnumerable<string> matchingNutrientNames, ObservableCollection<Nutrient> nutrients)
    {
        for (int i = 0; i < nutrients.Count; i++)
        {
            var nutrient = nutrients[i];
            if (!matchingNutrientNames.Contains(nutrient.Name))
                nutrients.RemoveAt(i);
        }
    }

    private async Task ShowDetailedNutrients()
    {
        if (SelectionCollection.CanExecuteCommand)
        {
            SetupNutrients(NutritionUtils.fats, Fats);
            SetupNutrients(NutritionUtils.DetailedAminoAcids, AminoAcids);

            await UpdateNutritionInformation();
        }

        SelectionCollection.CanExecuteCommand = false;
    }

    private async Task ShowBasicNutrients()
    {
        if (SelectionCollection.CanExecuteCommand)
        {
            RemoveNonMatchingNutrients(NutritionUtils.essentialAminoAcids, AminoAcids);

            await UpdateNutritionInformation();
        }

        SelectionCollection.CanExecuteCommand = false;
    }

    [RelayCommand]
    public async Task GoBack()
    {
        await Shell.Current.GoToAsync(nameof(MainPage));
    }
}
