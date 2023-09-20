using CommunityToolkit.Mvvm.Input;
using NutritionApp.MVVM.Models;
using NutritionApp.Services.NutritionServices.NutritionTrackingService;
using System.Collections.ObjectModel;

namespace NutritionApp.MVVM.ViewModels;

public partial class FoodDetailViewModel : BaseViewModel
{
    private readonly INutritionTracker nutritionTracker;
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

    public FoodDetailViewModel(FoodItem foodItem, INutritionTracker nutritionTracker)
    {
        FoodItem = foodItem;
        this.nutritionTracker = nutritionTracker;

        InitializeNutrients(nutritionTracker);
    }

    private void InitializeNutrients(INutritionTracker nutritionTracker)
    {
        //Main nutrients
        MainNutrients.Add(new Nutrient("Calories", Amount, FoodItem.Calories, nutritionTracker));
        MainNutrients.Add(new Nutrient("Protein", Amount, FoodItem.Protein, nutritionTracker));
        MainNutrients.Add(new Nutrient("Carbohydrates", Amount, FoodItem.Carbohydrates.Carbohydrate, nutritionTracker));
        MainNutrients.Add(new Nutrient("Fat", Amount, FoodItem.Fats.Fat, nutritionTracker));
        MainNutrients.Add(new Nutrient("SaturatedFat", Amount, FoodItem.Fats.SaturatedFat, nutritionTracker));
        MainNutrients.Add(new Nutrient("Cholesterol", Amount, FoodItem.Fats.Cholesterol, nutritionTracker));

        //Vitamins
        Vitamins.Add(new Nutrient("VitaminA", Amount, FoodItem.Vitamins.VitaminA, nutritionTracker));
        Vitamins.Add(new Nutrient("VitaminD", Amount, FoodItem.Vitamins.VitaminD, nutritionTracker));
        Vitamins.Add(new Nutrient("VitaminE", Amount, FoodItem.Vitamins.VitaminE, nutritionTracker));
        Vitamins.Add(new Nutrient("VitaminC", Amount, FoodItem.Vitamins.VitaminC, nutritionTracker));
        Vitamins.Add(new Nutrient("VitaminK", Amount, FoodItem.Vitamins.VitaminK, nutritionTracker));
        Vitamins.Add(new Nutrient("Thiamin", Amount, FoodItem.Vitamins.Thiamin, nutritionTracker));
        Vitamins.Add(new Nutrient("Riboflavin", Amount, FoodItem.Vitamins.Riboflavin, nutritionTracker));
        Vitamins.Add(new Nutrient("Niacin", Amount, FoodItem.Vitamins.Niacin, nutritionTracker));
        Vitamins.Add(new Nutrient("PantothenicAcid", Amount, FoodItem.Vitamins.PantothenicAcid, nutritionTracker));
        Vitamins.Add(new Nutrient("VitaminB6", Amount, FoodItem.Vitamins.VitaminB6, nutritionTracker));
        Vitamins.Add(new Nutrient("Folate", Amount, FoodItem.Vitamins.Folate, nutritionTracker));
        Vitamins.Add(new Nutrient("VitaminB12", Amount, FoodItem.Vitamins.VitaminB12, nutritionTracker));
        Vitamins.Add(new Nutrient("TocopherolAlpha", Amount, FoodItem.Vitamins.TocopherolAlpha, nutritionTracker));
        Vitamins.Add(new Nutrient("Choline", Amount, FoodItem.Vitamins.Choline, nutritionTracker));
        Vitamins.Add(new Nutrient("FolicAcid", Amount, FoodItem.Vitamins.FolicAcid, nutritionTracker));
        Vitamins.Add(new Nutrient("CaroteneAlpha", Amount, FoodItem.Vitamins.CaroteneAlpha, nutritionTracker));
        Vitamins.Add(new Nutrient("CaroteneBeta", Amount, FoodItem.Vitamins.CaroteneBeta, nutritionTracker));
        Vitamins.Add(new Nutrient("CryptoxanthinBeta", Amount, FoodItem.Vitamins.CryptoxanthinBeta, nutritionTracker));
        Vitamins.Add(new Nutrient("LuteinZeaxanthin", Amount, FoodItem.Vitamins.LuteinZeaxanthin, nutritionTracker));
        Vitamins.Add(new Nutrient("Lycopene", Amount, FoodItem.Vitamins.Lycopene, nutritionTracker));

        //Minerals
        Minerals.Add(new Nutrient("Calcium", Amount, FoodItem.Minerals.Calcium, nutritionTracker));
        Minerals.Add(new Nutrient("Iron", Amount, FoodItem.Minerals.Iron, nutritionTracker));
        Minerals.Add(new Nutrient("Zink", Amount, FoodItem.Minerals.Zink, nutritionTracker));
        Minerals.Add(new Nutrient("Sodium", Amount, FoodItem.Minerals.Sodium, nutritionTracker));
        Minerals.Add(new Nutrient("Magnesium", Amount, FoodItem.Minerals.Magnesium, nutritionTracker));
        Minerals.Add(new Nutrient("Copper", Amount, FoodItem.Minerals.Copper, nutritionTracker));
        Minerals.Add(new Nutrient("Manganese", Amount, FoodItem.Minerals.Manganese, nutritionTracker));
        Minerals.Add(new Nutrient("Phosphorous", Amount, FoodItem.Minerals.Phosphorous, nutritionTracker));
        Minerals.Add(new Nutrient("Selenium", Amount, FoodItem.Minerals.Selenium, nutritionTracker));

        //Amino Acids
        AminoAcids.Add(new Nutrient("Alanine", Amount, FoodItem.AminoAcids.Alanine, nutritionTracker));
        AminoAcids.Add(new Nutrient("Arginine", Amount, FoodItem.AminoAcids.Arginine, nutritionTracker));
        AminoAcids.Add(new Nutrient("AsparticAcid", Amount, FoodItem.AminoAcids.AsparticAcid, nutritionTracker));
        AminoAcids.Add(new Nutrient("Cystine", Amount, FoodItem.AminoAcids.Cystine, nutritionTracker));
        AminoAcids.Add(new Nutrient("GlutamicAcid", Amount, FoodItem.AminoAcids.GlutamicAcid, nutritionTracker));
        AminoAcids.Add(new Nutrient("Histidine", Amount, FoodItem.AminoAcids.Histidine, nutritionTracker));
        AminoAcids.Add(new Nutrient("Hydroxyproline", Amount, FoodItem.AminoAcids.Hydroxyproline, nutritionTracker));
        AminoAcids.Add(new Nutrient("Isoleucine", Amount, FoodItem.AminoAcids.Isoleucine, nutritionTracker));
        AminoAcids.Add(new Nutrient("Leucine", Amount, FoodItem.AminoAcids.Leucine, nutritionTracker));
        AminoAcids.Add(new Nutrient("Lysine", Amount, FoodItem.AminoAcids.Lysine, nutritionTracker));
        AminoAcids.Add(new Nutrient("Methionine", Amount, FoodItem.AminoAcids.Methionine, nutritionTracker));
        AminoAcids.Add(new Nutrient("Phenylalanine", Amount, FoodItem.AminoAcids.Phenylalanine, nutritionTracker));
        AminoAcids.Add(new Nutrient("Proline", Amount, FoodItem.AminoAcids.Proline, nutritionTracker));
        AminoAcids.Add(new Nutrient("Serine", Amount, FoodItem.AminoAcids.Serine, nutritionTracker));
        AminoAcids.Add(new Nutrient("Threonine", Amount, FoodItem.AminoAcids.Threonine, nutritionTracker));
        AminoAcids.Add(new Nutrient("Tryptophan", Amount, FoodItem.AminoAcids.Tryptophan, nutritionTracker));
        AminoAcids.Add(new Nutrient("Tyrosine", Amount, FoodItem.AminoAcids.Tyrosine, nutritionTracker));
        AminoAcids.Add(new Nutrient("Valine", Amount, FoodItem.AminoAcids.Valine, nutritionTracker));
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
