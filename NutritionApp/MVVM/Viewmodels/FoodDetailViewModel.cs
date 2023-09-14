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

    public double VitaminB1Amount => CalculateCurrentAmount(FoodItem.Vitamins.Thiamin);
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
        Calories = new(nutritionTracker.TotalKcal, FoodItem.Calories, nutrientSettings.KcalNeeded);
        Protein = new(nutritionTracker.TotalProtein, FoodItem.Protein, nutrientSettings.ProteinNeeded);
        Carbs = new(nutritionTracker.TotalCarbs, FoodItem.Carbohydrates.Carbohydrate, nutrientSettings.CarbsNeeded);
        Fat = new(nutritionTracker.TotalFat, FoodItem.Fats.Fat, nutrientSettings.FatNeeded);
        VitaminA = new(nutritionTracker.TotalVitaminA, FoodItem.Vitamins.VitaminA, nutrientSettings.VitaminANeeded);
        VitaminD = new(nutritionTracker.TotalVitaminD, FoodItem.Vitamins.VitaminD, nutrientSettings.VitaminDNeeded);
        VitaminE = new(nutritionTracker.TotalVitaminE, FoodItem.Vitamins.VitaminE, nutrientSettings.VitaminENeeded);
        VitaminC = new(nutritionTracker.TotalVitaminC, FoodItem.Vitamins.VitaminC, nutrientSettings.VitaminCNeeded);
        VitaminK = new(nutritionTracker.TotalVitaminK, FoodItem.Vitamins.VitaminK, nutrientSettings.VitaminKNeeded);
        UpdateAllOnPropertiesChanged();
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
    }
}
