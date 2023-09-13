using CommunityToolkit.Mvvm.ComponentModel;

namespace NutritionApp;

public partial class NutritionInformation : ObservableObject
{
    private double nutritionTotal;
    private readonly double nutritionAmountNeeded;
    private readonly double foodItemValue;

    [ObservableProperty]
    private double nutritionAmount = 0;

    [ObservableProperty]
    private double nutritionPotentialProgress;

    [ObservableProperty]
    private double nutritionProgress = 0;

    [ObservableProperty]
    private double currentItemValue;

    public NutritionInformation(double nutritionTotal, double foodItemValue, double nutritionAmountNeeded)
    {
        this.nutritionTotal = nutritionTotal;
        NutritionAmount = nutritionAmount;
        this.nutritionAmountNeeded = nutritionAmountNeeded;
        this.foodItemValue = foodItemValue;
    }

    public void SetProgress(double amount)
    {
        NutritionProgress = nutritionTotal / nutritionAmountNeeded;//fine
        NutritionPotentialProgress = CalculateProgress(amount, foodItemValue, nutritionAmountNeeded);
        CurrentItemValue = CalculateCurrentAmount(foodItemValue);
    }
    private double CalculateProgress(double currentValue, double foodItemValue, double targetValue)
    {
        return (currentValue + nutritionTotal * foodItemValue / 100) / targetValue;
    }
    private double CalculateCurrentAmount(double nutritionAmount) => Math.Round(nutritionAmount / 100 * nutritionTotal, 2);
}
