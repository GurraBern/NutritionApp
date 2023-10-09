using CommunityToolkit.Mvvm.Input;
using NutritionApp.MVVM.Models;
using NutritionApp.Services.NutritionServices;
using System.Collections.ObjectModel;

namespace NutritionApp.MVVM.ViewModels;

public partial class FoodDetailViewModel : BaseViewModel
{
    private readonly INutritionTracker nutritionTracker;
    private readonly INutrientFactory nutrientFactory;
    private int amount = 100;
    public ObservableCollection<Nutrient> MainNutrients { get; } = new();
    public ObservableCollection<Nutrient> Vitamins { get; } = new();
    public ObservableCollection<Nutrient> Minerals { get; } = new();
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
        InitializeNutrients();
    }

    private void InitializeNutrients()
    {
        // Main Nutrients
        MainNutrients.Add(nutrientFactory.CreateNutrient("Calories", Amount, FoodItem.Calories));
        MainNutrients.Add(nutrientFactory.CreateNutrient("Protein", Amount, FoodItem.Protein));
        MainNutrients.Add(nutrientFactory.CreateNutrient("Carbohydrates", Amount, FoodItem.Carbohydrate));
        MainNutrients.Add(nutrientFactory.CreateNutrient("Fiber", Amount, FoodItem.Fiber));
        MainNutrients.Add(nutrientFactory.CreateNutrient("Sugars", Amount, FoodItem.Sugar));
        MainNutrients.Add(nutrientFactory.CreateNutrient("Starch", Amount, FoodItem.Starch));
        MainNutrients.Add(nutrientFactory.CreateNutrient("Fat", Amount, FoodItem.TotalFat));
        MainNutrients.Add(nutrientFactory.CreateNutrient("SaturatedFat", Amount, FoodItem.TotalSaturatedFat));
        MainNutrients.Add(nutrientFactory.CreateNutrient("TransFat", Amount, FoodItem.TotalTransFat));
        MainNutrients.Add(nutrientFactory.CreateNutrient("MonounsaturatedFat", Amount, FoodItem.TotalMonounsaturated));
        MainNutrients.Add(nutrientFactory.CreateNutrient("PolyunsaturatedFat", Amount, FoodItem.TotalPolyunsaturated));
        MainNutrients.Add(nutrientFactory.CreateNutrient("Cholesterol", Amount, FoodItem.Cholesterol));

        // Vitamins
        Vitamins.Add(nutrientFactory.CreateNutrient("VitaminA", Amount, FoodItem.VitaminA));
        Vitamins.Add(nutrientFactory.CreateNutrient("Thiamin", Amount, FoodItem.Thiamin));
        Vitamins.Add(nutrientFactory.CreateNutrient("Riboflavin", Amount, FoodItem.Riboflavin));
        Vitamins.Add(nutrientFactory.CreateNutrient("Niacin", Amount, FoodItem.Niacin));
        Vitamins.Add(nutrientFactory.CreateNutrient("PantothenicAcid", Amount, FoodItem.PantothenicAcid));
        Vitamins.Add(nutrientFactory.CreateNutrient("VitaminB6", Amount, FoodItem.VitaminB6));
        Vitamins.Add(nutrientFactory.CreateNutrient("Biotin", Amount, FoodItem.Biotin));
        Vitamins.Add(nutrientFactory.CreateNutrient("Folate", Amount, FoodItem.Folate));
        Vitamins.Add(nutrientFactory.CreateNutrient("VitaminB12", Amount, FoodItem.VitaminB12));
        Vitamins.Add(nutrientFactory.CreateNutrient("VitaminC", Amount, FoodItem.VitaminC));
        Vitamins.Add(nutrientFactory.CreateNutrient("Choline", Amount, FoodItem.Choline));
        Vitamins.Add(nutrientFactory.CreateNutrient("VitaminD", Amount, FoodItem.VitaminD));
        Vitamins.Add(nutrientFactory.CreateNutrient("VitaminE", Amount, FoodItem.VitaminE));
        Vitamins.Add(nutrientFactory.CreateNutrient("VitaminK1", Amount, FoodItem.VitaminK1));
        Vitamins.Add(nutrientFactory.CreateNutrient("VitaminK2", Amount, FoodItem.VitaminK2));

        // Minerals
        Minerals.Add(nutrientFactory.CreateNutrient("Calcium", Amount, FoodItem.Calcium));
        Minerals.Add(nutrientFactory.CreateNutrient("Chromium", Amount, FoodItem.Chromium));
        Minerals.Add(nutrientFactory.CreateNutrient("Copper", Amount, FoodItem.Copper));
        Minerals.Add(nutrientFactory.CreateNutrient("Fluoride", Amount, FoodItem.Fluoride));
        Minerals.Add(nutrientFactory.CreateNutrient("Iodine", Amount, FoodItem.Iodine));
        Minerals.Add(nutrientFactory.CreateNutrient("Iron", Amount, FoodItem.Iron));
        Minerals.Add(nutrientFactory.CreateNutrient("Magnesium", Amount, FoodItem.Magnesium));
        Minerals.Add(nutrientFactory.CreateNutrient("Manganese", Amount, FoodItem.Manganese));
        Minerals.Add(nutrientFactory.CreateNutrient("Molybdenum", Amount, FoodItem.Molybdenum));
        Minerals.Add(nutrientFactory.CreateNutrient("Nickel", Amount, FoodItem.Nickel));
        Minerals.Add(nutrientFactory.CreateNutrient("Phosphorus", Amount, FoodItem.Phosphorus));
        Minerals.Add(nutrientFactory.CreateNutrient("Potassium", Amount, FoodItem.Potassium));
        Minerals.Add(nutrientFactory.CreateNutrient("Selenium", Amount, FoodItem.Selenium));
        Minerals.Add(nutrientFactory.CreateNutrient("Sodium", Amount, FoodItem.Sodium));
        Minerals.Add(nutrientFactory.CreateNutrient("Zinc", Amount, FoodItem.Zinc));

        // Amino Acids
        AminoAcids.Add(nutrientFactory.CreateNutrient("Alanine", Amount, FoodItem.Alanine));
        AminoAcids.Add(nutrientFactory.CreateNutrient("Arginine", Amount, FoodItem.Arginine));
        AminoAcids.Add(nutrientFactory.CreateNutrient("Asparagine", Amount, FoodItem.Asparagine));
        AminoAcids.Add(nutrientFactory.CreateNutrient("AsparticAcid", Amount, FoodItem.AsparticAcid));
        AminoAcids.Add(nutrientFactory.CreateNutrient("Cystine", Amount, FoodItem.Cystine));
        AminoAcids.Add(nutrientFactory.CreateNutrient("GlutamicAcid", Amount, FoodItem.GlutamicAcid));
        AminoAcids.Add(nutrientFactory.CreateNutrient("Glutamine", Amount, FoodItem.Glutamine));
        AminoAcids.Add(nutrientFactory.CreateNutrient("Glycine", Amount, FoodItem.Glycine));
        AminoAcids.Add(nutrientFactory.CreateNutrient("Histidine", Amount, FoodItem.Histidine));
        AminoAcids.Add(nutrientFactory.CreateNutrient("Isoleucine", Amount, FoodItem.Isoleucine));
        AminoAcids.Add(nutrientFactory.CreateNutrient("Leucine", Amount, FoodItem.Leucine));
        AminoAcids.Add(nutrientFactory.CreateNutrient("Lysine", Amount, FoodItem.Lysine));
        AminoAcids.Add(nutrientFactory.CreateNutrient("Methionine", Amount, FoodItem.Methionine));
        AminoAcids.Add(nutrientFactory.CreateNutrient("Phenylalanine", Amount, FoodItem.Phenylalanine));
        AminoAcids.Add(nutrientFactory.CreateNutrient("Proline", Amount, FoodItem.Proline));
        AminoAcids.Add(nutrientFactory.CreateNutrient("Serine", Amount, FoodItem.Serine));
        AminoAcids.Add(nutrientFactory.CreateNutrient("Threonine", Amount, FoodItem.Threonine));
        AminoAcids.Add(nutrientFactory.CreateNutrient("Tryptophan", Amount, FoodItem.Tryptophan));
        AminoAcids.Add(nutrientFactory.CreateNutrient("Tyrosine", Amount, FoodItem.Tyrosine));
        AminoAcids.Add(nutrientFactory.CreateNutrient("Valine", Amount, FoodItem.Valine));

        //Other
        Other.Add(nutrientFactory.CreateNutrient("CaroteneAlpha", Amount, FoodItem.CaroteneAlpha));
        Other.Add(nutrientFactory.CreateNutrient("CaroteneBeta", Amount, FoodItem.CaroteneBeta));
        Other.Add(nutrientFactory.CreateNutrient("CryptoxanthinBeta", Amount, FoodItem.CryptoxanthinBeta));
        Other.Add(nutrientFactory.CreateNutrient("LuteinZeaxanthin", Amount, FoodItem.LuteinZeaxanthin));
        Other.Add(nutrientFactory.CreateNutrient("Lycopene", Amount, FoodItem.Lycopene));
        Other.Add(nutrientFactory.CreateNutrient("Theobromine", Amount, FoodItem.Theobromine));
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
