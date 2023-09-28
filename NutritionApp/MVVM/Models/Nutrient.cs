using CommunityToolkit.Mvvm.ComponentModel;

namespace NutritionApp.MVVM.Models;

public partial class Nutrient : ObservableObject
{
    private readonly double nutritionTotal;
    private readonly double nutritionAmountNeeded;
    private readonly double foodItemValue;
    private NutritionDay nutritionDay;

    [ObservableProperty]
    private double nutritionAmount;

    [ObservableProperty]
    private double nutritionProgress;

    [ObservableProperty]
    private double nutritionPotentialProgress;

    [ObservableProperty]
    private double currentItemValue;
    public string Name { get; }

    public Nutrient(string name, double amount, double foodItemValue, ISettingsService settingsService, NutritionDay nutritionDay)
    {
        Name = name;
        nutritionAmount = amount;
        this.foodItemValue = foodItemValue;
        nutritionAmountNeeded = settingsService.Get(name);
        this.nutritionDay = nutritionDay;

        nutritionTotal = nutritionDay.NutrientTotals[name];

        Update(nutritionAmount);
    }

    public void Update(double amount = 1)
    {
        SetProgress(amount);
    }

    private void SetProgress(double amount)
    {
        NutritionAmount = amount;
        NutritionProgress = nutritionDay.NutrientTotals[Name] / nutritionAmountNeeded;
        NutritionPotentialProgress = CalculateProgress(amount);
        CurrentItemValue = NutritionAmount / 100 * foodItemValue;
    }

    private double CalculateProgress(double amount) =>
        (nutritionTotal + amount * foodItemValue / 100) / nutritionAmountNeeded;
}