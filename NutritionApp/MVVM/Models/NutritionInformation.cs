using CommunityToolkit.Mvvm.ComponentModel;

namespace NutritionApp;

public partial class NutritionInformation : ObservableObject
{
    private double nutritionTotal;
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

    public NutritionInformation(double nutritionTotal, double foodItemValue, double nutritionAmountNeeded)
    {
        this.nutritionTotal = nutritionTotal;
        this.nutritionAmountNeeded = nutritionAmountNeeded;
        this.foodItemValue = foodItemValue;
        SetProgress(nutritionAmount, nutritionTotal);
    }

    public void SetProgress(double amount, double itemValue)
    {
        NutritionAmount = amount;
        NutritionProgress = itemValue / nutritionAmountNeeded;
        NutritionPotentialProgress = CalculateProgress(nutritionTotal, nutritionAmountNeeded);
        CurrentItemValue = NutritionAmount / 100 * foodItemValue;
    }

    private double CalculateProgress(double total, double targetValue) =>
        (total + NutritionAmount * foodItemValue / 100) / targetValue;

    private double CalculateCurrentAmount() => Math.Round(NutritionAmount / 100 * foodItemValue, 2);
}