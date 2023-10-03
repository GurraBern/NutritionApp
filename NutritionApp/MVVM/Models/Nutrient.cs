using CommunityToolkit.Mvvm.ComponentModel;

namespace NutritionApp.MVVM.Models;

public partial class Nutrient : ObservableObject
{
    private double nutritionTotal = 0;
    private readonly double nutritionAmountNeeded;
    private readonly double foodItemValue;
    [ObservableProperty]
    private double nutritionAmount;

    [ObservableProperty]
    private double nutritionProgress;

    [ObservableProperty]
    private double nutritionPotentialProgress;

    [ObservableProperty]
    private double currentItemValue;
    public string Name { get; }

    public Nutrient(string name, double amount, double foodItemValue, ISettingsService settingsService)
    {
        Name = name;
        nutritionAmount = amount;
        this.foodItemValue = foodItemValue;

        nutritionAmountNeeded = settingsService.Get(name);
        SetProgress(nutritionAmount);
    }

    public void SetProgress(double amount = 0, double nutritionTotal = 0)
    {
        NutritionAmount = amount;
        this.nutritionTotal = nutritionTotal;
        NutritionProgress = nutritionTotal / nutritionAmountNeeded;
        NutritionPotentialProgress = CalculateProgress(amount);
        CurrentItemValue = NutritionAmount / 100 * foodItemValue;
    }

    private double CalculateProgress(double amount) =>
        (nutritionTotal + amount * foodItemValue / 100) / nutritionAmountNeeded;
}