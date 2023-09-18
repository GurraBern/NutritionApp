using CommunityToolkit.Mvvm.ComponentModel;
using NutritionApp.Services.NutritionServices.NutritionTrackingService;

namespace NutritionApp.MVVM.Models;

public partial class Nutrient : ObservableObject
{
    private double nutritionTotal;
    private readonly double nutritionAmountNeeded;
    private readonly double foodItemValue;
    private readonly INutritionTracker nutritionTracker;
    public string Name { get; }

    [ObservableProperty]
    private double nutritionAmount;

    [ObservableProperty]
    private double nutritionProgress;

    [ObservableProperty]
    private double nutritionPotentialProgress;

    [ObservableProperty]
    private double currentItemValue;

    public Nutrient(string name, double amount, double foodItemValue, INutritionTracker nutritionTracker)
    {
        Name = name;
        nutritionAmount = amount;
        this.foodItemValue = foodItemValue;
        this.nutritionTracker = nutritionTracker;

        nutritionTotal = nutritionTracker.NutrientTotals[name];
        nutritionAmountNeeded = nutritionTracker.NutrientNeeds[name];
        SetProgress(nutritionAmount, nutritionTotal);
    }

    public void SetProgress(double amount, double itemValue)
    {
        NutritionAmount = amount;
        NutritionProgress = nutritionTracker.NutrientTotals[Name] / nutritionAmountNeeded;
        NutritionPotentialProgress = CalculateProgress(amount);
        CurrentItemValue = NutritionAmount / 100 * foodItemValue;
    }

    public void Update(double amount)
    {
        var needs = nutritionTracker.NutrientNeeds[Name];
        SetProgress(amount, needs);
    }

    private double CalculateProgress(double amount) =>
        (nutritionTotal + amount * foodItemValue / 100) / nutritionAmountNeeded;
}