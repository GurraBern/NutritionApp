using CommunityToolkit.Mvvm.ComponentModel;
using Nutrition.Core;

namespace NutritionApp.MVVM.Models;

public partial class NutrientModel(Nutrient nutrient, double nutrientValue) : ObservableObject
{
    [ObservableProperty]
    private double nutritionProgress;

    [ObservableProperty]
    private double nutritionPotentialProgress;

    private readonly double nutritionAmountNeeded = nutrient.Amount;
    public readonly double foodItemValue = nutrientValue;
    public readonly int sortValue;
    public string Name { get; } = nutrient.NutrientName;
    public string CustomName { get; set; }
    public string unit = string.Empty;
    public string Title => $"{(string.IsNullOrEmpty(CustomName) ? Name : CustomName)}";
    public string Info => $"{Math.Round(CurrentItemValue, roundingAmount)}/{nutritionAmountNeeded} {unit}";
    public string NutritionLeft => CurrentItemValue < nutritionAmountNeeded ? Math.Round(nutritionAmountNeeded - CurrentItemValue, roundingAmount).ToString() : "0";
    public int roundingAmount = 0;

    private double _currentItemValue;

    public double CurrentItemValue
    {
        get { return Math.Round(_currentItemValue, roundingAmount); }
        set
        {
            if (SetProperty(ref _currentItemValue, value))
            {
                OnPropertyChanged(nameof(Info));
                OnPropertyChanged(nameof(NutritionLeft));
            }
        }
    }

    public void SetProgress(double amount, double nutritionTotal = 0)
    {
        NutritionProgress = nutritionTotal / nutritionAmountNeeded;
        CurrentItemValue = amount;
    }

    public void SetPotentialProgress(double amount, double nutritionTotal = 0)
    {
        NutritionPotentialProgress = CalculateProgress(amount, nutritionTotal);
    }

    private double CalculateProgress(double amount, double total)
    {
        return (total + amount) / nutritionAmountNeeded;
    }
}