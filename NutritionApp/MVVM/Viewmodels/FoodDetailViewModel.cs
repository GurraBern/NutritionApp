using CommunityToolkit.Mvvm.Input;
using Nutrition.Core;
using NutritionApp.MVVM.Models;
using NutritionApp.Services.NutritionServices;
using System.Collections.ObjectModel;

namespace NutritionApp.MVVM.ViewModels;

public partial class FoodDetailViewModel : BaseViewModel
{
    private readonly INutritionTracker nutritionTracker;
    private readonly INutrientFactory nutrientFactory;
    private NutritionDay nutritionDay;
    private int amount = 100;
    public ObservableCollection<Nutrient> PrimaryNutrients { get; } = new();
    public ObservableCollection<Nutrient> Vitamins { get; } = new();
    public ObservableCollection<Nutrient> MacroMinerals { get; } = new();
    public ObservableCollection<Nutrient> AminoAcids { get; } = new();
    public ObservableCollection<Nutrient> Other { get; } = new();
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

    public FoodDetailViewModel(FoodItem foodItem, INutritionTracker nutritionTracker, INutrientFactory nutrientFactory)
    {
        FoodItem = foodItem;
        this.nutritionTracker = nutritionTracker;
        this.nutrientFactory = nutrientFactory;
    }

    public async Task Initialize()
    {
        InitializeNutrients();
        nutritionDay = await nutritionTracker.GetSelectedNutritionDay();
        UpdateAllOnPropertiesChanged();
    }

    private void InitializeNutrients()
    {
        // Main Nutrients
        PrimaryNutrients.Add(nutrientFactory.CreateNutrient("Calories", FoodItem.Calories));
        PrimaryNutrients.Add(nutrientFactory.CreateNutrient("Protein", FoodItem.Protein));
        PrimaryNutrients.Add(nutrientFactory.CreateNutrient("Carbohydrates", FoodItem.Carbohydrate));
        PrimaryNutrients.Add(nutrientFactory.CreateNutrient("Fiber", FoodItem.Fiber));
        PrimaryNutrients.Add(nutrientFactory.CreateNutrient("Sugars", FoodItem.Sugar));
        PrimaryNutrients.Add(nutrientFactory.CreateNutrient("Starch", FoodItem.Starch));
        PrimaryNutrients.Add(nutrientFactory.CreateNutrient("Fat", FoodItem.TotalFat));
        PrimaryNutrients.Add(nutrientFactory.CreateNutrient("SaturatedFat", FoodItem.TotalSaturatedFat));
        PrimaryNutrients.Add(nutrientFactory.CreateNutrient("TransFat", FoodItem.TotalTransFat));
        PrimaryNutrients.Add(nutrientFactory.CreateNutrient("MonounsaturatedFat", FoodItem.TotalMonounsaturated));
        PrimaryNutrients.Add(nutrientFactory.CreateNutrient("PolyunsaturatedFat", FoodItem.TotalPolyunsaturated));
        PrimaryNutrients.Add(nutrientFactory.CreateNutrient("Cholesterol", FoodItem.Cholesterol));

        // Vitamins
        Vitamins.Add(nutrientFactory.CreateNutrient("VitaminA", FoodItem.VitaminA));
        Vitamins.Add(nutrientFactory.CreateNutrient("Thiamin", FoodItem.Thiamin));
        Vitamins.Add(nutrientFactory.CreateNutrient("Riboflavin", FoodItem.Riboflavin));
        Vitamins.Add(nutrientFactory.CreateNutrient("Niacin", FoodItem.Niacin));
        Vitamins.Add(nutrientFactory.CreateNutrient("PantothenicAcid", FoodItem.PantothenicAcid));
        Vitamins.Add(nutrientFactory.CreateNutrient("VitaminB6", FoodItem.VitaminB6));
        Vitamins.Add(nutrientFactory.CreateNutrient("Biotin", FoodItem.Biotin));
        Vitamins.Add(nutrientFactory.CreateNutrient("Folate", FoodItem.Folate));
        Vitamins.Add(nutrientFactory.CreateNutrient("VitaminB12", FoodItem.VitaminB12));
        Vitamins.Add(nutrientFactory.CreateNutrient("VitaminC", FoodItem.VitaminC));
        Vitamins.Add(nutrientFactory.CreateNutrient("Choline", FoodItem.Choline));
        Vitamins.Add(nutrientFactory.CreateNutrient("VitaminD", FoodItem.VitaminD));
        Vitamins.Add(nutrientFactory.CreateNutrient("VitaminE", FoodItem.VitaminE));
        Vitamins.Add(nutrientFactory.CreateNutrient("VitaminK1", FoodItem.VitaminK1));
        Vitamins.Add(nutrientFactory.CreateNutrient("VitaminK2", FoodItem.VitaminK2));

        // Minerals
        MacroMinerals.Add(nutrientFactory.CreateNutrient("Calcium", FoodItem.Calcium));
        MacroMinerals.Add(nutrientFactory.CreateNutrient("Chromium", FoodItem.Chromium));
        MacroMinerals.Add(nutrientFactory.CreateNutrient("Copper", FoodItem.Copper));
        MacroMinerals.Add(nutrientFactory.CreateNutrient("Fluoride", FoodItem.Fluoride));
        MacroMinerals.Add(nutrientFactory.CreateNutrient("Iodine", FoodItem.Iodine));
        MacroMinerals.Add(nutrientFactory.CreateNutrient("Iron", FoodItem.Iron));
        MacroMinerals.Add(nutrientFactory.CreateNutrient("Magnesium", FoodItem.Magnesium));
        MacroMinerals.Add(nutrientFactory.CreateNutrient("Manganese", FoodItem.Manganese));
        MacroMinerals.Add(nutrientFactory.CreateNutrient("Molybdenum", FoodItem.Molybdenum));
        MacroMinerals.Add(nutrientFactory.CreateNutrient("Nickel", FoodItem.Nickel));
        MacroMinerals.Add(nutrientFactory.CreateNutrient("Phosphorus", FoodItem.Phosphorus));
        MacroMinerals.Add(nutrientFactory.CreateNutrient("Potassium", FoodItem.Potassium));
        MacroMinerals.Add(nutrientFactory.CreateNutrient("Selenium", FoodItem.Selenium));
        MacroMinerals.Add(nutrientFactory.CreateNutrient("Sodium", FoodItem.Sodium));
        MacroMinerals.Add(nutrientFactory.CreateNutrient("Zinc", FoodItem.Zinc));

        // Amino Acids
        AminoAcids.Add(nutrientFactory.CreateNutrient("Alanine", FoodItem.Alanine));
        AminoAcids.Add(nutrientFactory.CreateNutrient("Arginine", FoodItem.Arginine));
        AminoAcids.Add(nutrientFactory.CreateNutrient("Asparagine", FoodItem.Asparagine));
        AminoAcids.Add(nutrientFactory.CreateNutrient("AsparticAcid", FoodItem.AsparticAcid));
        AminoAcids.Add(nutrientFactory.CreateNutrient("Cystine", FoodItem.Cystine));
        AminoAcids.Add(nutrientFactory.CreateNutrient("GlutamicAcid", FoodItem.GlutamicAcid));
        AminoAcids.Add(nutrientFactory.CreateNutrient("Glutamine", FoodItem.Glutamine));
        AminoAcids.Add(nutrientFactory.CreateNutrient("Glycine", FoodItem.Glycine));
        AminoAcids.Add(nutrientFactory.CreateNutrient("Histidine", FoodItem.Histidine));
        AminoAcids.Add(nutrientFactory.CreateNutrient("Isoleucine", FoodItem.Isoleucine));
        AminoAcids.Add(nutrientFactory.CreateNutrient("Leucine", FoodItem.Leucine));
        AminoAcids.Add(nutrientFactory.CreateNutrient("Lysine", FoodItem.Lysine));
        AminoAcids.Add(nutrientFactory.CreateNutrient("Methionine", FoodItem.Methionine));
        AminoAcids.Add(nutrientFactory.CreateNutrient("Phenylalanine", FoodItem.Phenylalanine));
        AminoAcids.Add(nutrientFactory.CreateNutrient("Proline", FoodItem.Proline));
        AminoAcids.Add(nutrientFactory.CreateNutrient("Serine", FoodItem.Serine));
        AminoAcids.Add(nutrientFactory.CreateNutrient("Threonine", FoodItem.Threonine));
        AminoAcids.Add(nutrientFactory.CreateNutrient("Tryptophan", FoodItem.Tryptophan));
        AminoAcids.Add(nutrientFactory.CreateNutrient("Tyrosine", FoodItem.Tyrosine));
        AminoAcids.Add(nutrientFactory.CreateNutrient("Valine", FoodItem.Valine));

        //Other
        Other.Add(nutrientFactory.CreateNutrient("CaroteneAlpha", FoodItem.CaroteneAlpha));
        Other.Add(nutrientFactory.CreateNutrient("CaroteneBeta", FoodItem.CaroteneBeta));
        Other.Add(nutrientFactory.CreateNutrient("CryptoxanthinBeta", FoodItem.CryptoxanthinBeta));
        Other.Add(nutrientFactory.CreateNutrient("LuteinZeaxanthin", FoodItem.LuteinZeaxanthin));
        Other.Add(nutrientFactory.CreateNutrient("Lycopene", FoodItem.Lycopene));
        Other.Add(nutrientFactory.CreateNutrient("Theobromine", FoodItem.Theobromine));
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
        foreach (var nutrient in PrimaryNutrients.Concat(Vitamins).Concat(MacroMinerals).Concat(AminoAcids))
        {
            var nutrientAmount = Convert.ToDouble(Amount) * nutrient.foodItemValue / 100;
            nutrient.SetProgress(nutrientAmount, nutritionDay.NutrientTotals[nutrient.Name]);
            nutrient.SetPotentialProgress(nutrientAmount, nutritionDay.NutrientTotals[nutrient.Name]);
        }
    }
}
