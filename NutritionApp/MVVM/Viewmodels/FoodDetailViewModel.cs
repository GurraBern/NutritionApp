using CommunityToolkit.Mvvm.Input;
using NutritionApp.MVVM.Models;
using NutritionApp.Services.NutritionServices;
using NutritionApp.Services.NutritionServices.NutritionTrackingService;

namespace NutritionApp.MVVM.ViewModels;

public partial class FoodDetailViewModel : BaseViewModel
{
    private readonly INutritionTracker nutritionTracker;
    private readonly INutrientSettings nutrientSettings;
    private int amount = 100;
    public FoodItem FoodItem { get; }

    //Main nutrients
    public NutritionInformation Calories { get; set; }
    public NutritionInformation Protein { get; set; }
    public NutritionInformation Carbs { get; set; }
    public NutritionInformation Fat { get; set; }    
    public NutritionInformation SaturatedFat { get; set; }
    public NutritionInformation Cholesterol { get; set; }

    //Vitamins
    public NutritionInformation VitaminA { get; set; }
    public NutritionInformation VitaminD { get; set; }
    public NutritionInformation VitaminE { get; set; }
    public NutritionInformation VitaminC { get; set; }
    public NutritionInformation VitaminK { get; set; }
    public NutritionInformation Thiamin { get; set; }
    public NutritionInformation Riboflavin { get; set; }
    public NutritionInformation Niacin { get; set; }
    public NutritionInformation PantothenicAcid { get; set; }
    public NutritionInformation VitaminB6 { get; set; }
    //VitaminB7?
    public NutritionInformation Folate { get; set; }
    public NutritionInformation VitaminB12 { get; set; }
    public NutritionInformation TocopherolAlpha { get; set; }
    public NutritionInformation Choline { get; set; }
    public NutritionInformation FolicAcid { get; set; }
    public NutritionInformation CaroteneAlpha { get; set; }
    public NutritionInformation CaroteneBeta { get; set; }
    public NutritionInformation CryptoxanthinBeta { get; set; }
    public NutritionInformation LuteinZeaxanthin { get; set; }
    public NutritionInformation Lycopene { get; set; }

    //Minerals
    public NutritionInformation Calcium { get; set; }
    public NutritionInformation Iron { get; set; }
    public NutritionInformation Zink { get; set; }
    public NutritionInformation Potassium { get; set; }
    public NutritionInformation Sodium { get; set; }
    public NutritionInformation Magnesium { get; set; }
    public NutritionInformation Copper { get; set; }
    public NutritionInformation Manganese { get; set; }
    public NutritionInformation Phosphorous { get; set; }
    public NutritionInformation Selenium { get; set; }

    //Aminoacids
    public NutritionInformation Alanine { get; set; }
    public NutritionInformation Arginine { get; set; }
    public NutritionInformation AsparticAcid { get; set; }
    public NutritionInformation Cystine { get; set; }
    public NutritionInformation GlutamicAcid { get; set; }
    public NutritionInformation Glycine { get; set; }
    public NutritionInformation Histidine { get; set; }
    public NutritionInformation Hydroxyproline { get; set; }
    public NutritionInformation Isoleucine { get; set; }
    public NutritionInformation Leucine { get; set; }
    public NutritionInformation Lysine { get; set; }
    public NutritionInformation Methionine { get; set; }
    public NutritionInformation Phenylalanine { get; set; }
    public NutritionInformation Proline { get; set; }
    public NutritionInformation Serine { get; set; }
    public NutritionInformation Threonine { get; set; }
    public NutritionInformation Tryptophan { get; set; }
    public NutritionInformation Tyrosine { get; set; }
    public NutritionInformation Valine { get; set; }
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

    public FoodDetailViewModel(FoodItem foodItem, INutritionTracker nutritionTracker, INutrientSettings nutrientSettings)
    {
        FoodItem = foodItem;
        this.nutritionTracker = nutritionTracker;
        this.nutrientSettings = nutrientSettings;
        
        InitializeNutrients();
        UpdateAllOnPropertiesChanged();
    }

    private void InitializeNutrients()
    {
        Calories = new(nutritionTracker.TotalKcal, FoodItem.Calories, nutrientSettings.KcalNeeded);
        Protein = new(nutritionTracker.TotalProtein, FoodItem.Protein, nutrientSettings.ProteinNeeded);
        Carbs = new(nutritionTracker.TotalCarbs, FoodItem.Carbohydrates.Carbohydrate, nutrientSettings.CarbsNeeded);
        Fat = new(nutritionTracker.TotalFat, FoodItem.Fats.Fat, nutrientSettings.FatNeeded);
        SaturatedFat = new(nutritionTracker.TotalSaturatedFat, FoodItem.Fats.SaturatedFat, nutrientSettings.SaturatedFatNeeded);
        Cholesterol = new(nutritionTracker.TotalCholesterol, FoodItem.Fats.Cholesterol, nutrientSettings.CholesterolNeeded);
        VitaminA = new(nutritionTracker.TotalVitaminA, FoodItem.Vitamins.VitaminA, nutrientSettings.VitaminANeeded);
        VitaminD = new(nutritionTracker.TotalVitaminD, FoodItem.Vitamins.VitaminD, nutrientSettings.VitaminDNeeded);
        VitaminE = new(nutritionTracker.TotalVitaminE, FoodItem.Vitamins.VitaminE, nutrientSettings.VitaminENeeded);
        VitaminC = new(nutritionTracker.TotalVitaminC, FoodItem.Vitamins.VitaminC, nutrientSettings.VitaminCNeeded);
        VitaminK = new(nutritionTracker.TotalVitaminK, FoodItem.Vitamins.VitaminK, nutrientSettings.VitaminKNeeded);
        Thiamin = new(nutritionTracker.TotalThiamin, FoodItem.Vitamins.Thiamin, nutrientSettings.ThiaminNeeded);
        Riboflavin = new(nutritionTracker.TotalRiboflavin, FoodItem.Vitamins.Riboflavin, nutrientSettings.RiboflavinNeeded);
        Niacin = new(nutritionTracker.TotalNiacin, FoodItem.Vitamins.Niacin, nutrientSettings.NiacinNeeded);
        PantothenicAcid = new(nutritionTracker.TotalNiacin, FoodItem.Vitamins.Niacin, nutrientSettings.NiacinNeeded);
        VitaminB6 = new(nutritionTracker.TotalVitaminB6, FoodItem.Vitamins.VitaminB6, nutrientSettings.VitaminB6Needed);
        Folate = new(nutritionTracker.TotalFolate, FoodItem.Vitamins.Folate, nutrientSettings.FolateNeeded);
        VitaminB12 = new(nutritionTracker.TotalVitaminB12, FoodItem.Vitamins.VitaminB12, nutrientSettings.VitaminB12Needed);
        TocopherolAlpha = new(nutritionTracker.TotalTocopherolAlpha, FoodItem.Vitamins.TocopherolAlpha, nutrientSettings.TocopherolAlphaNeeded);
        Choline = new(nutritionTracker.TotalCholine, FoodItem.Vitamins.Choline, nutrientSettings.CholineNeeded);
        FolicAcid = new(nutritionTracker.TotalFolicAcid, FoodItem.Vitamins.FolicAcid, nutrientSettings.FolicAcidNeeded);
        CaroteneAlpha = new(nutritionTracker.TotalCaroteneAlpha, FoodItem.Vitamins.CaroteneAlpha, nutrientSettings.CaroteneAlphaNeeded);
        CaroteneBeta = new(nutritionTracker.TotalCaroteneBeta, FoodItem.Vitamins.CaroteneBeta, nutrientSettings.CaroteneBetaNeeded);
        CryptoxanthinBeta = new(nutritionTracker.TotalCryptoxanthinBeta, FoodItem.Vitamins.CryptoxanthinBeta, nutrientSettings.CryptoxanthinBetaNeeded);
        LuteinZeaxanthin = new(nutritionTracker.TotalLuteinZeaxanthin, FoodItem.Vitamins.LuteinZeaxanthin, nutrientSettings.LuteinZeaxanthinNeeded);
        Lycopene = new(nutritionTracker.TotalLycopene, FoodItem.Vitamins.Lycopene, nutrientSettings.LycopeneNeeded);
        Calcium = new(nutritionTracker.TotalCalcium, FoodItem.Minerals.Calcium, nutrientSettings.CalciumNeeded);
        Iron = new(nutritionTracker.TotalIron, FoodItem.Minerals.Iron, nutrientSettings.IronNeeded);
        Zink = new(nutritionTracker.TotalZink, FoodItem.Minerals.Zink, nutrientSettings.ZinkNeeded);
        Sodium = new(nutritionTracker.TotalSodium, FoodItem.Minerals.Sodium, nutrientSettings.SodiumNeeded);
        Magnesium = new(nutritionTracker.TotalMagnesium, FoodItem.Minerals.Magnesium, nutrientSettings.MagnesiumNeeded);
        Copper = new(nutritionTracker.TotalCopper, FoodItem.Minerals.Copper, nutrientSettings.CopperNeeded);
        Manganese = new(nutritionTracker.TotalManganese, FoodItem.Minerals.Manganese, nutrientSettings.ManganeseNeeded);
        Phosphorous = new(nutritionTracker.TotalPhosphorous, FoodItem.Minerals.Phosphorous, nutrientSettings.PhosphorousNeeded);
        Selenium = new(nutritionTracker.TotalSelenium, FoodItem.Minerals.Selenium, nutrientSettings.SeleniumNeeded);
        Alanine = new(nutritionTracker.TotalAlanine, FoodItem.AminoAcids.Alanine, nutrientSettings.AlanineNeeded);
        Arginine = new(nutritionTracker.TotalArginine, FoodItem.AminoAcids.Arginine, nutrientSettings.ArginineNeeded);
        AsparticAcid = new(nutritionTracker.TotalAsparticAcid, FoodItem.AminoAcids.AsparticAcid, nutrientSettings.AsparticAcidNeeded);
        Cystine = new(nutritionTracker.TotalCystine, FoodItem.AminoAcids.Cystine, nutrientSettings.CystineNeeded);
        GlutamicAcid = new(nutritionTracker.TotalGlutamicAcid, FoodItem.AminoAcids.GlutamicAcid, nutrientSettings.GlutamicAcidNeeded);
        Histidine = new(nutritionTracker.TotalHistidine, FoodItem.AminoAcids.Histidine, nutrientSettings.HistidineNeeded);
        Hydroxyproline = new(nutritionTracker.TotalHydroxyproline, FoodItem.AminoAcids.Hydroxyproline, nutrientSettings.HydroxyprolineNeeded);
        Isoleucine = new(nutritionTracker.TotalIsoleucine, FoodItem.AminoAcids.Isoleucine, nutrientSettings.IsoleucineNeeded);
        Leucine = new(nutritionTracker.TotalLeucine, FoodItem.AminoAcids.Leucine, nutrientSettings.LeucineNeeded);
        Lysine = new(nutritionTracker.TotalLysine, FoodItem.AminoAcids.Lysine, nutrientSettings.LysineNeeded);
        Methionine = new(nutritionTracker.TotalMethionine, FoodItem.AminoAcids.Methionine, nutrientSettings.MethionineNeeded);
        Phenylalanine = new(nutritionTracker.TotalPhenylalanine, FoodItem.AminoAcids.Phenylalanine, nutrientSettings.PhenylalanineNeeded);
        Proline = new(nutritionTracker.TotalProline, FoodItem.AminoAcids.Proline, nutrientSettings.ProlineNeeded);
        Serine = new(nutritionTracker.TotalSerine, FoodItem.AminoAcids.Serine, nutrientSettings.SerineNeeded);
        Threonine = new(nutritionTracker.TotalThreonine, FoodItem.AminoAcids.Threonine, nutrientSettings.ThreonineNeeded);
        Tryptophan = new(nutritionTracker.TotalTryptophan, FoodItem.AminoAcids.Tryptophan, nutrientSettings.TryptophanNeeded);
        Tyrosine = new(nutritionTracker.TotalTyrosine, FoodItem.AminoAcids.Tyrosine, nutrientSettings.TyrosineNeeded);
        Valine = new(nutritionTracker.TotalValine, FoodItem.AminoAcids.Valine, nutrientSettings.ValineNeeded);
    }

    [RelayCommand]
    public async Task AddFood()
    {
        FoodItem.Amount = Amount;
        nutritionTracker.AddFood(FoodItem);

        await Shell.Current.GoToAsync("//MainPage");
    }

    private double CalculateCurrentAmount(double nutritionAmount) => Math.Round(nutritionAmount / 100 * Amount, 2);

    private void UpdateAllOnPropertiesChanged()
    {
        OnPropertyChanged(nameof(Amount));
        Calories.SetProgress(Amount, nutritionTracker.TotalKcal);
        Protein.SetProgress(Amount, nutritionTracker.TotalProtein);
        Carbs.SetProgress(Amount, nutritionTracker.TotalCarbs);
        Fat.SetProgress(Amount, nutritionTracker.TotalFat);
        SaturatedFat.SetProgress(Amount, nutritionTracker.TotalSaturatedFat);
        Cholesterol.SetProgress(Amount, nutritionTracker.TotalCholesterol);
        VitaminA.SetProgress(Amount, nutritionTracker.TotalVitaminA);
        VitaminD.SetProgress(Amount, nutritionTracker.TotalVitaminD);
        VitaminE.SetProgress(Amount, nutritionTracker.TotalVitaminE);
        VitaminC.SetProgress(Amount, nutritionTracker.TotalVitaminC);
        VitaminK.SetProgress(Amount, nutritionTracker.TotalVitaminK);
        Thiamin.SetProgress(Amount, nutritionTracker.TotalThiamin);
        Riboflavin.SetProgress(Amount, nutritionTracker.TotalRiboflavin);
        Niacin.SetProgress(Amount, nutritionTracker.TotalNiacin);
        PantothenicAcid.SetProgress(Amount, nutritionTracker.TotalPantothenicAcid);
        VitaminB6.SetProgress(Amount, nutritionTracker.TotalVitaminB6);
        Folate.SetProgress(Amount, nutritionTracker.TotalFolate);
        VitaminB12.SetProgress(Amount, nutritionTracker.TotalVitaminB12);
        Choline.SetProgress(Amount, nutritionTracker.TotalCholine);
        FolicAcid.SetProgress(Amount, nutritionTracker.TotalFolicAcid);
        CaroteneAlpha.SetProgress(Amount, nutritionTracker.TotalCaroteneAlpha);
        CaroteneBeta.SetProgress(Amount, nutritionTracker.TotalCaroteneBeta);
        CryptoxanthinBeta.SetProgress(Amount, nutritionTracker.TotalCryptoxanthinBeta);
        LuteinZeaxanthin.SetProgress(Amount, nutritionTracker.TotalLuteinZeaxanthin);
        Lycopene.SetProgress(Amount, nutritionTracker.TotalLycopene);
        Calcium.SetProgress(Amount, nutritionTracker.TotalCalcium);
        Iron.SetProgress(Amount, nutritionTracker.TotalIron);
        Zink.SetProgress(Amount, nutritionTracker.TotalZink);
        Sodium.SetProgress(Amount, nutritionTracker.TotalSodium);
        Magnesium.SetProgress(Amount, nutritionTracker.TotalMagnesium);
        Copper.SetProgress(Amount, nutritionTracker.TotalCopper);
        Manganese.SetProgress(Amount, nutritionTracker.TotalManganese);
        Phosphorous.SetProgress(Amount, nutritionTracker.TotalPhosphorous);
        Selenium.SetProgress(Amount, nutritionTracker.TotalSelenium);
        Alanine.SetProgress(Amount, nutritionTracker.TotalAlanine);
        Arginine.SetProgress(Amount, nutritionTracker.TotalArginine);
        AsparticAcid.SetProgress(Amount, nutritionTracker.TotalAsparticAcid);
        Cystine.SetProgress(Amount, nutritionTracker.TotalCystine);
        GlutamicAcid.SetProgress(Amount, nutritionTracker.TotalGlutamicAcid);
        Histidine.SetProgress(Amount, nutritionTracker.TotalHistidine);
        Hydroxyproline.SetProgress(Amount, nutritionTracker.TotalHydroxyproline);
        Isoleucine.SetProgress(Amount, nutritionTracker.TotalIsoleucine);
        Leucine.SetProgress(Amount, nutritionTracker.TotalLeucine);
        Lysine.SetProgress(Amount, nutritionTracker.TotalLysine);
        Methionine.SetProgress(Amount, nutritionTracker.TotalMethionine);
        Phenylalanine.SetProgress(Amount, nutritionTracker.TotalPhenylalanine);
        Proline.SetProgress(Amount, nutritionTracker.TotalProline);
        Serine.SetProgress(Amount, nutritionTracker.TotalSerine);
        Threonine.SetProgress(Amount, nutritionTracker.TotalThreonine);
        Tyrosine.SetProgress(Amount, nutritionTracker.TotalTyrosine);
        Valine.SetProgress(Amount, nutritionTracker.TotalValine);
    }
}
