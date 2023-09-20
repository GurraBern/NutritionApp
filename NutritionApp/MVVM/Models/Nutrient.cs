using CommunityToolkit.Mvvm.ComponentModel;
using NutritionApp.Services.NutritionServices.NutritionTrackingService;

namespace NutritionApp.MVVM.Models;

public partial class Nutrient : ObservableObject
{
    private readonly double nutritionTotal;
    private readonly double nutritionAmountNeeded;
    private readonly double foodItemValue;
    private readonly INutritionTracker nutritionTracker;

    [ObservableProperty]
    private double nutritionAmount;

    [ObservableProperty]
    private double nutritionProgress;

    [ObservableProperty]
    private double nutritionPotentialProgress;

    [ObservableProperty]
    private double currentItemValue;
    public string Name { get; }

    public Nutrient(string name, double amount, double foodItemValue, INutritionTracker nutritionTracker)
    {
        Name = name;
        nutritionAmount = amount;
        this.foodItemValue = foodItemValue;
        this.nutritionTracker = nutritionTracker;

        nutritionTotal = nutritionTracker.NutrientTotals[name];
        nutritionAmountNeeded = nutritionTracker.NutrientNeeds[name];
        Update(nutritionAmount);
    }

    public void Update(double amount = 1)
    {
        SetProgress(amount);
    }

    private void SetProgress(double amount)
    {
        NutritionAmount = amount;
        NutritionProgress = nutritionTracker.NutrientTotals[Name] / nutritionAmountNeeded;
        NutritionPotentialProgress = CalculateProgress(amount);
        CurrentItemValue = NutritionAmount / 100 * foodItemValue;
    }

    private double CalculateProgress(double amount) =>
        (nutritionTotal + amount * foodItemValue / 100) / nutritionAmountNeeded;
}