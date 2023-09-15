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
    public NutritionInformation Calories { get; set; }
    public NutritionInformation Protein { get; set; }
    public NutritionInformation Carbs { get; set; }
    public NutritionInformation Fat { get; set; }
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


    
    //public double CaroteneAlpha { get; set; }
    //public double CaroteneBeta { get; set; }
    //public double CryptoxanthinBeta { get; set; }
    //public double LuteinZeaxanthin { get; set; }
    //public double Lycopene { get; set; }
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
    }
}
