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
    public ObservableCollection<Nutrient> MainNutrients { get; set; } = new();
    public ObservableCollection<Nutrient> Vitamins { get; set; } = new();
    public ObservableCollection<Nutrient> Minerals { get; set; } = new();
    public ObservableCollection<Nutrient> AminoAcids { get; set; } = new();
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
        var nutritionDay = nutritionTracker.NutritionDay;
        //Main nutrients
        MainNutrients.Add(new Nutrient("Calories", Amount, FoodItem.Calories, settingsService, nutritionDay));
        MainNutrients.Add(new Nutrient("Protein", Amount, FoodItem.Protein, settingsService, nutritionDay));
        MainNutrients.Add(new Nutrient("Carbohydrates", Amount, FoodItem.Carbohydrates.Carbohydrate, settingsService, nutritionDay));
        MainNutrients.Add(new Nutrient("Fat", Amount, FoodItem.Fats.Fat, settingsService, nutritionDay));
        MainNutrients.Add(new Nutrient("SaturatedFat", Amount, FoodItem.Fats.SaturatedFat, settingsService, nutritionDay));
        MainNutrients.Add(new Nutrient("Cholesterol", Amount, FoodItem.Fats.Cholesterol, settingsService, nutritionDay));

        //Vitamins
        Vitamins.Add(new Nutrient("VitaminA", Amount, FoodItem.Vitamins.VitaminA, settingsService, nutritionDay));
        Vitamins.Add(new Nutrient("VitaminD", Amount, FoodItem.Vitamins.VitaminD, settingsService, nutritionDay));
        Vitamins.Add(new Nutrient("VitaminE", Amount, FoodItem.Vitamins.VitaminE, settingsService, nutritionDay));
        Vitamins.Add(new Nutrient("VitaminC", Amount, FoodItem.Vitamins.VitaminC, settingsService, nutritionDay));
        Vitamins.Add(new Nutrient("VitaminK", Amount, FoodItem.Vitamins.VitaminK, settingsService, nutritionDay));
        Vitamins.Add(new Nutrient("Thiamin", Amount, FoodItem.Vitamins.Thiamin, settingsService, nutritionDay));
        Vitamins.Add(new Nutrient("Riboflavin", Amount, FoodItem.Vitamins.Riboflavin, settingsService, nutritionDay));
        Vitamins.Add(new Nutrient("Niacin", Amount, FoodItem.Vitamins.Niacin, settingsService, nutritionDay));
        Vitamins.Add(new Nutrient("PantothenicAcid", Amount, FoodItem.Vitamins.PantothenicAcid, settingsService, nutritionDay));
        Vitamins.Add(new Nutrient("VitaminB6", Amount, FoodItem.Vitamins.VitaminB6, settingsService, nutritionDay));
        Vitamins.Add(new Nutrient("Folate", Amount, FoodItem.Vitamins.Folate, settingsService, nutritionDay));
        Vitamins.Add(new Nutrient("VitaminB12", Amount, FoodItem.Vitamins.VitaminB12, settingsService, nutritionDay));
        Vitamins.Add(new Nutrient("TocopherolAlpha", Amount, FoodItem.Vitamins.TocopherolAlpha, settingsService, nutritionDay));
        Vitamins.Add(new Nutrient("Choline", Amount, FoodItem.Vitamins.Choline, settingsService, nutritionDay));
        Vitamins.Add(new Nutrient("FolicAcid", Amount, FoodItem.Vitamins.FolicAcid, settingsService, nutritionDay));
        Vitamins.Add(new Nutrient("CaroteneAlpha", Amount, FoodItem.Vitamins.CaroteneAlpha, settingsService, nutritionDay));
        Vitamins.Add(new Nutrient("CaroteneBeta", Amount, FoodItem.Vitamins.CaroteneBeta, settingsService, nutritionDay));
        Vitamins.Add(new Nutrient("CryptoxanthinBeta", Amount, FoodItem.Vitamins.CryptoxanthinBeta, settingsService, nutritionDay));
        Vitamins.Add(new Nutrient("LuteinZeaxanthin", Amount, FoodItem.Vitamins.LuteinZeaxanthin, settingsService, nutritionDay));
        Vitamins.Add(new Nutrient("Lycopene", Amount, FoodItem.Vitamins.Lycopene, settingsService, nutritionDay));

        //Minerals
        Minerals.Add(new Nutrient("Calcium", Amount, FoodItem.Minerals.Calcium, settingsService, nutritionDay));
        Minerals.Add(new Nutrient("Iron", Amount, FoodItem.Minerals.Iron, settingsService, nutritionDay));
        Minerals.Add(new Nutrient("Zink", Amount, FoodItem.Minerals.Zink, settingsService, nutritionDay));
        Minerals.Add(new Nutrient("Sodium", Amount, FoodItem.Minerals.Sodium, settingsService, nutritionDay));
        Minerals.Add(new Nutrient("Magnesium", Amount, FoodItem.Minerals.Magnesium, settingsService, nutritionDay));
        Minerals.Add(new Nutrient("Copper", Amount, FoodItem.Minerals.Copper, settingsService, nutritionDay));
        Minerals.Add(new Nutrient("Manganese", Amount, FoodItem.Minerals.Manganese, settingsService, nutritionDay));
        Minerals.Add(new Nutrient("Phosphorous", Amount, FoodItem.Minerals.Phosphorous, settingsService, nutritionDay));
        Minerals.Add(new Nutrient("Selenium", Amount, FoodItem.Minerals.Selenium, settingsService, nutritionDay));

        //Amino Acids
        AminoAcids.Add(new Nutrient("Alanine", Amount, FoodItem.AminoAcids.Alanine, settingsService, nutritionDay));
        AminoAcids.Add(new Nutrient("Arginine", Amount, FoodItem.AminoAcids.Arginine, settingsService, nutritionDay));
        AminoAcids.Add(new Nutrient("AsparticAcid", Amount, FoodItem.AminoAcids.AsparticAcid, settingsService, nutritionDay));
        AminoAcids.Add(new Nutrient("Cystine", Amount, FoodItem.AminoAcids.Cystine, settingsService, nutritionDay));
        AminoAcids.Add(new Nutrient("GlutamicAcid", Amount, FoodItem.AminoAcids.GlutamicAcid, settingsService, nutritionDay));
        AminoAcids.Add(new Nutrient("Histidine", Amount, FoodItem.AminoAcids.Histidine, settingsService, nutritionDay));
        AminoAcids.Add(new Nutrient("Hydroxyproline", Amount, FoodItem.AminoAcids.Hydroxyproline, settingsService, nutritionDay));
        AminoAcids.Add(new Nutrient("Isoleucine", Amount, FoodItem.AminoAcids.Isoleucine, settingsService, nutritionDay));
        AminoAcids.Add(new Nutrient("Leucine", Amount, FoodItem.AminoAcids.Leucine, settingsService, nutritionDay));
        AminoAcids.Add(new Nutrient("Lysine", Amount, FoodItem.AminoAcids.Lysine, settingsService, nutritionDay));
        AminoAcids.Add(new Nutrient("Methionine", Amount, FoodItem.AminoAcids.Methionine, settingsService, nutritionDay));
        AminoAcids.Add(new Nutrient("Phenylalanine", Amount, FoodItem.AminoAcids.Phenylalanine, settingsService, nutritionDay));
        AminoAcids.Add(new Nutrient("Proline", Amount, FoodItem.AminoAcids.Proline, settingsService, nutritionDay));
        AminoAcids.Add(new Nutrient("Serine", Amount, FoodItem.AminoAcids.Serine, settingsService, nutritionDay));
        AminoAcids.Add(new Nutrient("Threonine", Amount, FoodItem.AminoAcids.Threonine, settingsService, nutritionDay));
        AminoAcids.Add(new Nutrient("Tryptophan", Amount, FoodItem.AminoAcids.Tryptophan, settingsService, nutritionDay));
        AminoAcids.Add(new Nutrient("Tyrosine", Amount, FoodItem.AminoAcids.Tyrosine, settingsService, nutritionDay));
        AminoAcids.Add(new Nutrient("Valine", Amount, FoodItem.AminoAcids.Valine, settingsService, nutritionDay));
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
        OnPropertyChanged(nameof(Amount));

        foreach (var nutrient in MainNutrients)
        {
            nutrient.Update(Amount);
        }

        foreach (var nutrient in Vitamins)
        {
            nutrient.Update(Amount);
        }

        foreach (var nutrient in Minerals)
        {
            nutrient.Update(Amount);
        }

        foreach (var nutrient in AminoAcids)
        {
            nutrient.Update(Amount);
        }
    }
}
