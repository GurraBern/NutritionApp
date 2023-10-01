using CommunityToolkit.Mvvm.Input;
using NutritionApp.MVVM.Models;
using NutritionApp.Services.NutritionServices;
using System.Collections.ObjectModel;

namespace NutritionApp.MVVM.ViewModels;

public partial class FoodDetailViewModel : BaseViewModel
{
    private readonly INutritionTracker nutritionTracker;
    private readonly ISettingsService settingsService;
    private int amount = 100;
    public ObservableCollection<Nutrient> MainNutrients { get; } = new();
    public ObservableCollection<Nutrient> Vitamins { get; } = new();
    public ObservableCollection<Nutrient> Minerals { get; } = new();
    public ObservableCollection<Nutrient> AminoAcids { get; } = new();
    public FoodItem FoodItem { get; }
    public int Amount
    {
        get => amount;
        set
        {
            if (amount != value)
            {
                amount = value;
                UpdateAllOnPropertiesChanged();
                OnPropertyChanged(nameof(Amount));
            }
        }
    }

    public FoodDetailViewModel(FoodItem foodItem, INutritionTracker nutritionTracker, ISettingsService settingsService)
    {
        FoodItem = foodItem;
        this.nutritionTracker = nutritionTracker;
        this.settingsService = settingsService;
        InitializeNutrients();
    }

    private void InitializeNutrients()
    {
        //Main nutrients
        MainNutrients.Add(new Nutrient("Calories", Amount, FoodItem.Calories, settingsService));
        MainNutrients.Add(new Nutrient("Protein", Amount, FoodItem.Protein, settingsService));
        MainNutrients.Add(new Nutrient("Carbohydrates", Amount, FoodItem.Carbohydrate, settingsService));
        MainNutrients.Add(new Nutrient("Fat", Amount, FoodItem.Fat, settingsService));
        MainNutrients.Add(new Nutrient("SaturatedFat", Amount, FoodItem.SaturatedFat, settingsService));
        MainNutrients.Add(new Nutrient("Cholesterol", Amount, FoodItem.Cholesterol, settingsService));

        ////Vitamins
        Vitamins.Add(new Nutrient("VitaminA", Amount, FoodItem.VitaminA, settingsService));
        Vitamins.Add(new Nutrient("VitaminD", Amount, FoodItem.VitaminD, settingsService));
        Vitamins.Add(new Nutrient("VitaminE", Amount, FoodItem.VitaminE, settingsService));
        Vitamins.Add(new Nutrient("VitaminC", Amount, FoodItem.VitaminC, settingsService));
        Vitamins.Add(new Nutrient("VitaminK", Amount, FoodItem.VitaminK, settingsService));
        Vitamins.Add(new Nutrient("Thiamin", Amount, FoodItem.Thiamin, settingsService));
        Vitamins.Add(new Nutrient("Riboflavin", Amount, FoodItem.Riboflavin, settingsService));
        Vitamins.Add(new Nutrient("Niacin", Amount, FoodItem.Niacin, settingsService));
        Vitamins.Add(new Nutrient("PantothenicAcid", Amount, FoodItem.PantothenicAcid, settingsService));
        Vitamins.Add(new Nutrient("VitaminB6", Amount, FoodItem.VitaminB6, settingsService));
        Vitamins.Add(new Nutrient("Folate", Amount, FoodItem.Folate, settingsService));
        Vitamins.Add(new Nutrient("VitaminB12", Amount, FoodItem.VitaminB12, settingsService));
        Vitamins.Add(new Nutrient("TocopherolAlpha", Amount, FoodItem.TocopherolAlpha, settingsService));
        Vitamins.Add(new Nutrient("Choline", Amount, FoodItem.Choline, settingsService));
        Vitamins.Add(new Nutrient("FolicAcid", Amount, FoodItem.FolicAcid, settingsService));
        Vitamins.Add(new Nutrient("CaroteneAlpha", Amount, FoodItem.CaroteneAlpha, settingsService));
        Vitamins.Add(new Nutrient("CaroteneBeta", Amount, FoodItem.CaroteneBeta, settingsService));
        Vitamins.Add(new Nutrient("CryptoxanthinBeta", Amount, FoodItem.CryptoxanthinBeta, settingsService));
        Vitamins.Add(new Nutrient("LuteinZeaxanthin", Amount, FoodItem.LuteinZeaxanthin, settingsService));
        Vitamins.Add(new Nutrient("Lycopene", Amount, FoodItem.Lycopene, settingsService));

        ////Minerals
        Minerals.Add(new Nutrient("Calcium", Amount, FoodItem.Calcium, settingsService));
        Minerals.Add(new Nutrient("Iron", Amount, FoodItem.Iron, settingsService));
        Minerals.Add(new Nutrient("Zink", Amount, FoodItem.Zink, settingsService));
        Minerals.Add(new Nutrient("Sodium", Amount, FoodItem.Sodium, settingsService));
        Minerals.Add(new Nutrient("Magnesium", Amount, FoodItem.Magnesium, settingsService));
        Minerals.Add(new Nutrient("Copper", Amount, FoodItem.Copper, settingsService));
        Minerals.Add(new Nutrient("Manganese", Amount, FoodItem.Manganese, settingsService));
        Minerals.Add(new Nutrient("Phosphorous", Amount, FoodItem.Phosphorous, settingsService));
        Minerals.Add(new Nutrient("Selenium", Amount, FoodItem.Selenium, settingsService));

        //Amino Acids
        AminoAcids.Add(new Nutrient("Alanine", Amount, FoodItem.Alanine, settingsService));
        AminoAcids.Add(new Nutrient("Arginine", Amount, FoodItem.Arginine, settingsService));
        AminoAcids.Add(new Nutrient("AsparticAcid", Amount, FoodItem.AsparticAcid, settingsService));
        AminoAcids.Add(new Nutrient("Cystine", Amount, FoodItem.Cystine, settingsService));
        AminoAcids.Add(new Nutrient("GlutamicAcid", Amount, FoodItem.GlutamicAcid, settingsService));
        AminoAcids.Add(new Nutrient("Histidine", Amount, FoodItem.Histidine, settingsService));
        AminoAcids.Add(new Nutrient("Hydroxyproline", Amount, FoodItem.Hydroxyproline, settingsService));
        AminoAcids.Add(new Nutrient("Isoleucine", Amount, FoodItem.Isoleucine, settingsService));
        AminoAcids.Add(new Nutrient("Leucine", Amount, FoodItem.Leucine, settingsService));
        AminoAcids.Add(new Nutrient("Lysine", Amount, FoodItem.Lysine, settingsService));
        AminoAcids.Add(new Nutrient("Methionine", Amount, FoodItem.Methionine, settingsService));
        AminoAcids.Add(new Nutrient("Phenylalanine", Amount, FoodItem.Phenylalanine, settingsService));
        AminoAcids.Add(new Nutrient("Proline", Amount, FoodItem.Proline, settingsService));
        AminoAcids.Add(new Nutrient("Serine", Amount, FoodItem.Serine, settingsService));
        AminoAcids.Add(new Nutrient("Threonine", Amount, FoodItem.Threonine, settingsService));
        AminoAcids.Add(new Nutrient("Tryptophan", Amount, FoodItem.Tryptophan, settingsService));
        AminoAcids.Add(new Nutrient("Tyrosine", Amount, FoodItem.Tyrosine, settingsService));
        AminoAcids.Add(new Nutrient("Valine", Amount, FoodItem.Valine, settingsService));
    }

    [RelayCommand]
    public async Task AddFood()
    {
        FoodItem.Amount = Amount;
        nutritionTracker.AddFood(FoodItem);

        await Shell.Current.GoToAsync("//MainPage");
    }

    private void UpdateAllOnPropertiesChanged()
    {
        foreach (var nutrient in MainNutrients.Concat(Vitamins).Concat(Minerals).Concat(AminoAcids))
        {
            nutrient.SetProgress(Amount);
        }
    }
}
