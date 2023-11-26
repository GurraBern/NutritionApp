using CommunityToolkit.Mvvm.ComponentModel;
using Nutrition.Core;

namespace NutritionApp.MVVM.Models;

public partial class NutrientModel : ObservableObject
{
    [ObservableProperty]
    private double nutritionProgress;

    [ObservableProperty]
    private double nutritionPotentialProgress;

    private readonly double nutritionAmountNeeded;
    private readonly Nutrient nutrient;
    public readonly double foodItemValue;
    public readonly int sortValue;
    public string Name { get; }
    public string CustomName { get; set; }
    public string unit = string.Empty;
    public string Title => $"{(string.IsNullOrEmpty(CustomName) ? Name : CustomName)}";
    public string Info => $"{Math.Round(CurrentItemValue, roundingAmount)}/{nutritionAmountNeeded} {unit}";
    public string NutritionLeft => (nutritionAmountNeeded - CurrentItemValue).ToString();
    public int roundingAmount = 0;

    private double _currentItemValue;
    public double CurrentItemValue
    {
        get { return _currentItemValue; }
        set
        {
            if (SetProperty(ref _currentItemValue, value))
            {
                OnPropertyChanged(nameof(Info));
                OnPropertyChanged(nameof(NutritionLeft));
            }
        }
    }

    public NutrientModel(Nutrient nutrient, double nutrientValue)
    {
        Name = nutrient.NutrientName;
        this.nutrient = nutrient;
        foodItemValue = nutrientValue;
        nutritionAmountNeeded = nutrient.Amount;
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