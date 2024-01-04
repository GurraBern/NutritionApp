using CommunityToolkit.Mvvm.ComponentModel;
using Nutrition.Core;

namespace NutritionApp.MVVM.Models;

public partial class NutrientModel(Nutrient nutrient, double nutrientValue) : ObservableObject
{
    [ObservableProperty]
    private double nutritionProgress;

    [ObservableProperty]
    private double nutritionPotentialProgress;

    public readonly double foodItemValue = nutrientValue;
    public string Name { get; } = nutrient.NutrientName;
    public string CustomName { get; set; }
    public bool ShowUnit { get; set; } = true;
    public string Title => $"{(string.IsNullOrEmpty(CustomName) ? Name : CustomName)}";
    public string Info => $"{Math.Round(CurrentItemValue, roundingAmount)}/{nutrient.Amount} {(ShowUnit ? nutrient.Unit : "")}";
    public string NutritionLeft => CurrentItemValue < nutrient.Amount ? Math.Round(nutrient.Amount - CurrentItemValue, roundingAmount).ToString() : "0";
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
        var nutritionAmountNeeded = nutrient.Amount;
        NutritionProgress = nutritionTotal / nutritionAmountNeeded;
        CurrentItemValue = amount;
    }

    public void SetPotentialProgress(double amount, double nutritionTotal = 0)
    {
        NutritionPotentialProgress = CalculateProgress(amount, nutritionTotal);
    }

    private double CalculateProgress(double amount, double total)
    {
        var nutritionAmountNeeded = nutrient.Amount;
        return (total + amount) / nutritionAmountNeeded;
    }
}