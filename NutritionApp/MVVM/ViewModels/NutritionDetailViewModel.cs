using CommunityToolkit.Mvvm.ComponentModel;
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
    public ObservableCollection<NutrientModel> PrimaryNutrients { get; set; } = new();
    public ObservableCollection<NutrientModel> Fats { get; } = new();
    public ObservableCollection<NutrientModel> Vitamins { get; } = new();
    public ObservableCollection<NutrientModel> MacroMinerals { get; } = new();
    public ObservableCollection<NutrientModel> AminoAcids { get; } = new();

    [ObservableProperty]
    private OptionItem selectedOption;
    public ObservableCollection<OptionItem> Options { get; private set; } = new();


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
        Options.Add(basicOption);

        var advancedOption = new OptionItem("Detailed", new AsyncRelayCommand(ShowDetailedNutrients));
        Options.Add(advancedOption);

        SelectedOption = basicOption;
    }

    private void SetupAllNutrients()
    {
        SetupNutrients(NutritionUtils.mainNutrients, PrimaryNutrients);
        SetupNutrients(NutritionUtils.fats, Fats);
        SetupNutrients(NutritionUtils.vitamins, Vitamins);
        SetupNutrients(NutritionUtils.macroMinerals, MacroMinerals);
        SetupNutrients(NutritionUtils.essentialAminoAcids, AminoAcids);
    }

    private void SetupNutrients(IEnumerable<string> nutrientNames, ObservableCollection<NutrientModel> nutrientCollection)
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

    private static void RemoveNonMatchingNutrients(IEnumerable<string> matchingNutrientNames, ObservableCollection<NutrientModel> nutrients)
    {
        for (int i = 0; i < nutrients.Count; i++)
        {
            var nutrient = nutrients[i];
            if (!matchingNutrientNames.Contains(nutrient.Name))
                nutrients.RemoveAt(i);
        }
    }

    public async Task ShowDetailedNutrients()
    {
        SetupNutrients(NutritionUtils.fats, Fats);
        SetupNutrients(NutritionUtils.DetailedAminoAcids, AminoAcids);

        SortAllNutrients();

        await UpdateNutritionInformation();
    }

    public async Task ShowBasicNutrients()
    {
        RemoveNonMatchingNutrients(NutritionUtils.essentialAminoAcids, AminoAcids);

        SortAllNutrients();

        await UpdateNutritionInformation();
    }

    private void SortAllNutrients()
    {
        PrimaryNutrients.SortByNutritionProgress();
        MacroMinerals.SortByNutritionProgress();
        Vitamins.SortByNutritionProgress();
    }

    [RelayCommand]
    public async Task GoBack()
    {
        await Shell.Current.GoToAsync(nameof(MainPage));
    }
}
