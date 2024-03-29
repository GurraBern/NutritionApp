﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Nutrition.Core;
using NutritionApp.Data.Services;
using NutritionApp.MVVM.Models;
using NutritionApp.MVVM.Viewmodels.Utils;
using NutritionApp.MVVM.Views;
using System.Collections.ObjectModel;

namespace NutritionApp.MVVM.ViewModels;

public partial class NutritionDetailViewModel : BaseViewModel, IAsyncInitialization, IRecipient<FoodItem>
{
    private readonly INutritionTracker nutritionTracker;
    private readonly INutrientFactory nutrientFactory;
    private NutritionDay nutritionDay;

    [ObservableProperty]
    private OptionItem selectedOption;

    public ObservableCollection<NutrientModel> PrimaryNutrients { get; set; } = [];
    public ObservableCollection<NutrientModel> Fats { get; } = [];
    public ObservableCollection<NutrientModel> Vitamins { get; } = [];
    public ObservableCollection<NutrientModel> MacroMinerals { get; } = [];
    public ObservableCollection<NutrientModel> AminoAcids { get; } = [];
    public ObservableCollection<OptionItem> Options { get; private set; } = [];
    public Task Initialization { get; private set; }

    public NutritionDetailViewModel(INutritionTracker nutritionTracker, INutrientFactory nutrientFactory)
    {
        this.nutritionTracker = nutritionTracker;
        this.nutrientFactory = nutrientFactory;

        Initialization = InitializeAsync();

        WeakReferenceMessenger.Default.Register(this);
    }

    private async Task InitializeAsync()
    {
        nutritionDay = await nutritionTracker.GetSelectedNutritionDay();

        SetupAllNutrients();
        SetupOptions();

        UpdateNutritionInformation();
        ShowBasicNutrients();
    }

    private void SetupOptions()
    {
        var basicOption = new OptionItem("Basic", new RelayCommand(ShowBasicNutrients));
        Options.Add(basicOption);

        var advancedOption = new OptionItem("Detailed", new RelayCommand(ShowDetailedNutrients));
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
            nutrient.roundingAmount = 4;
            if (nutrient != null)
                nutrientCollection.Add(nutrient);
        }
    }

    public void UpdateNutritionInformation()
    {
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

    public void ShowDetailedNutrients()
    {
        SetupNutrients(NutritionUtils.fats, Fats);
        SetupNutrients(NutritionUtils.DetailedAminoAcids, AminoAcids);

        SortAllNutrients();

        //UpdateNutritionInformation();
    }

    public void ShowBasicNutrients()
    {
        RemoveNonMatchingNutrients(NutritionUtils.essentialAminoAcids, AminoAcids);

        SortAllNutrients();

        //UpdateNutritionInformation();
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

    public void Receive(FoodItem message)
    {
        UpdateNutritionInformation();
    }
}