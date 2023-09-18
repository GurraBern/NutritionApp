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
        UpdateAllOnPropertiesChanged();
    }

    private void InitializeNutrients(INutritionTracker nutritionTracker)
    {
        //Main nutrients
        MainNutrients.Add(new Nutrient("Calories", Amount, FoodItem.Calories, nutritionTracker));
        //MainNutrients.Add(new Nutrient("Protein", nutritionTracker.TotalProtein, FoodItem.Protein, nutrientSettings.ProteinNeeded));
        //MainNutrients.Add(new Nutrient("Carbs", nutritionTracker.TotalCarbs, FoodItem.Carbohydrates.Carbohydrate, nutrientSettings.CarbsNeeded));
        //MainNutrients.Add(new Nutrient("Fat", nutritionTracker.TotalFat, FoodItem.Fats.Fat, nutrientSettings.FatNeeded));
        //MainNutrients.Add(new Nutrient("SaturatedFat", nutritionTracker.TotalSaturatedFat, FoodItem.Fats.SaturatedFat, nutrientSettings.SaturatedFatNeeded));
        //MainNutrients.Add(new Nutrient("Cholesterol", nutritionTracker.TotalCholesterol, FoodItem.Fats.Cholesterol, nutrientSettings.CholesterolNeeded));

        ////Vitamins
        //Vitamins.Add(new Nutrient("VitaminA", nutritionTracker.TotalVitaminA, FoodItem.Vitamins.VitaminA, nutrientSettings.VitaminANeeded));
        //Vitamins.Add(new Nutrient("VitaminD", nutritionTracker.TotalVitaminD, FoodItem.Vitamins.VitaminD, nutrientSettings.VitaminDNeeded));
        //Vitamins.Add(new Nutrient("VitaminE", nutritionTracker.TotalVitaminE, FoodItem.Vitamins.VitaminE, nutrientSettings.VitaminENeeded));
        //Vitamins.Add(new Nutrient("VitaminC", nutritionTracker.TotalVitaminC, FoodItem.Vitamins.VitaminC, nutrientSettings.VitaminCNeeded));
        //Vitamins.Add(new Nutrient("VitaminK", nutritionTracker.TotalVitaminK, FoodItem.Vitamins.VitaminK, nutrientSettings.VitaminKNeeded));
        //Vitamins.Add(new Nutrient("Thiamin", nutritionTracker.TotalThiamin, FoodItem.Vitamins.Thiamin, nutrientSettings.ThiaminNeeded));
        //Vitamins.Add(new Nutrient("Riboflavin", nutritionTracker.TotalRiboflavin, FoodItem.Vitamins.Riboflavin, nutrientSettings.RiboflavinNeeded));
        //Vitamins.Add(new Nutrient("Niacin", nutritionTracker.TotalNiacin, FoodItem.Vitamins.Niacin, nutrientSettings.NiacinNeeded));
        //Vitamins.Add(new Nutrient("PantothenicAcid", nutritionTracker.TotalNiacin, FoodItem.Vitamins.Niacin, nutrientSettings.NiacinNeeded));
        //Vitamins.Add(new Nutrient("VitaminB6", nutritionTracker.TotalVitaminB6, FoodItem.Vitamins.VitaminB6, nutrientSettings.VitaminB6Needed));
        //Vitamins.Add(new Nutrient("Folate", nutritionTracker.TotalFolate, FoodItem.Vitamins.Folate, nutrientSettings.FolateNeeded));
        //Vitamins.Add(new Nutrient("VitaminB12", nutritionTracker.TotalVitaminB12, FoodItem.Vitamins.VitaminB12, nutrientSettings.VitaminB12Needed));
        //Vitamins.Add(new Nutrient("TocopherolAlpha", nutritionTracker.TotalTocopherolAlpha, FoodItem.Vitamins.TocopherolAlpha, nutrientSettings.TocopherolAlphaNeeded));
        //Vitamins.Add(new Nutrient("Choline", nutritionTracker.TotalCholine, FoodItem.Vitamins.Choline, nutrientSettings.CholineNeeded));
        //Vitamins.Add(new Nutrient("FolicAcid", nutritionTracker.TotalFolicAcid, FoodItem.Vitamins.FolicAcid, nutrientSettings.FolicAcidNeeded));
        //Vitamins.Add(new Nutrient("CaroteneAlpha", nutritionTracker.TotalCaroteneAlpha, FoodItem.Vitamins.CaroteneAlpha, nutrientSettings.CaroteneAlphaNeeded));
        //Vitamins.Add(new Nutrient("CaroteneBeta", nutritionTracker.TotalCaroteneBeta, FoodItem.Vitamins.CaroteneBeta, nutrientSettings.CaroteneBetaNeeded));
        //Vitamins.Add(new Nutrient("CryptoxanthinBeta", nutritionTracker.TotalCryptoxanthinBeta, FoodItem.Vitamins.CryptoxanthinBeta, nutrientSettings.CryptoxanthinBetaNeeded));
        //Vitamins.Add(new Nutrient("LuteinZeaxanthin", nutritionTracker.TotalLuteinZeaxanthin, FoodItem.Vitamins.LuteinZeaxanthin, nutrientSettings.LuteinZeaxanthinNeeded));
        //Vitamins.Add(new Nutrient("Lycopene", nutritionTracker.TotalLycopene, FoodItem.Vitamins.Lycopene, nutrientSettings.LycopeneNeeded));

        ////Minerals
        //Minerals.Add(new Nutrient("Calcium", nutritionTracker.TotalCalcium, FoodItem.Minerals.Calcium, nutrientSettings.CalciumNeeded));
        //Minerals.Add(new Nutrient("Iron", nutritionTracker.TotalIron, FoodItem.Minerals.Iron, nutrientSettings.IronNeeded));
        //Minerals.Add(new Nutrient("Zink", nutritionTracker.TotalZink, FoodItem.Minerals.Zink, nutrientSettings.ZinkNeeded));
        //Minerals.Add(new Nutrient("Sodium", nutritionTracker.TotalSodium, FoodItem.Minerals.Sodium, nutrientSettings.SodiumNeeded));
        //Minerals.Add(new Nutrient("Magnesium", nutritionTracker.TotalMagnesium, FoodItem.Minerals.Magnesium, nutrientSettings.MagnesiumNeeded));
        //Minerals.Add(new Nutrient("Copper", nutritionTracker.TotalCopper, FoodItem.Minerals.Copper, nutrientSettings.CopperNeeded));
        //Minerals.Add(new Nutrient("Manganese", nutritionTracker.TotalManganese, FoodItem.Minerals.Manganese, nutrientSettings.ManganeseNeeded));
        //Minerals.Add(new Nutrient("Phosphorous", nutritionTracker.TotalPhosphorous, FoodItem.Minerals.Phosphorous, nutrientSettings.PhosphorousNeeded));
        //Minerals.Add(new Nutrient("Selenium", nutritionTracker.TotalSelenium, FoodItem.Minerals.Selenium, nutrientSettings.SeleniumNeeded));

        //////Amino Acids
        //AminoAcids.Add(new Nutrient("Alanine", nutritionTracker.TotalAlanine, FoodItem.AminoAcids.Alanine, nutrientSettings.AlanineNeeded));
        //AminoAcids.Add(new Nutrient("Arginine", nutritionTracker.TotalArginine, FoodItem.AminoAcids.Arginine, nutrientSettings.ArginineNeeded));
        //AminoAcids.Add(new Nutrient("AsparticAcid", nutritionTracker.TotalAsparticAcid, FoodItem.AminoAcids.AsparticAcid, nutrientSettings.AsparticAcidNeeded));
        //AminoAcids.Add(new Nutrient("Cystine", nutritionTracker.TotalCystine, FoodItem.AminoAcids.Cystine, nutrientSettings.CystineNeeded));
        //AminoAcids.Add(new Nutrient("GlutamicAcid", nutritionTracker.TotalGlutamicAcid, FoodItem.AminoAcids.GlutamicAcid, nutrientSettings.GlutamicAcidNeeded));
        //AminoAcids.Add(new Nutrient("Histidine", nutritionTracker.TotalHistidine, FoodItem.AminoAcids.Histidine, nutrientSettings.HistidineNeeded));
        //AminoAcids.Add(new Nutrient("Hydroxyproline", nutritionTracker.TotalHydroxyproline, FoodItem.AminoAcids.Hydroxyproline, nutrientSettings.HydroxyprolineNeeded));
        //AminoAcids.Add(new Nutrient("Isoleucine", nutritionTracker.TotalIsoleucine, FoodItem.AminoAcids.Isoleucine, nutrientSettings.IsoleucineNeeded));
        //AminoAcids.Add(new Nutrient("Leucine", nutritionTracker.TotalLeucine, FoodItem.AminoAcids.Leucine, nutrientSettings.LeucineNeeded));
        //AminoAcids.Add(new Nutrient("Lysine", nutritionTracker.TotalLysine, FoodItem.AminoAcids.Lysine, nutrientSettings.LysineNeeded));
    }

    [RelayCommand]
    public async Task AddFood()
    {
        FoodItem.Amount = Amount;
        nutritionTracker.AddFood(FoodItem);

        await Shell.Current.GoToAsync("//MainPage");
    }

    private async Task UpdateAllOnPropertiesChanged()
    {
        OnPropertyChanged(nameof(Amount));

        foreach (var nutrient in MainNutrients)
        {
            nutrient.Update(Amount);
        }
    }
}
