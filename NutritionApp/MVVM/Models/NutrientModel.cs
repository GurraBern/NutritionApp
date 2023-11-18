using CommunityToolkit.Mvvm.ComponentModel;
using NutritionApp.Services.NutritionServices;

namespace NutritionApp.MVVM.Models;

public partial class NutrientModel : ObservableObject
{
    [ObservableProperty]
    private double nutritionProgress;

    [ObservableProperty]
    private double nutritionPotentialProgress;

    private readonly double nutritionAmountNeeded;
    public readonly double foodItemValue;
    public readonly int sortValue;
    public string Name { get; }
    public string CustomName { get; set; }
    public string unit = string.Empty;
    public string Title => $"{(string.IsNullOrEmpty(CustomName) ? Name : CustomName)}";
    public string Info => $"{Math.Round(CurrentItemValue, roundingAmount)}/{nutritionAmountNeeded} {unit}";
    public int roundingAmount = 0;

    private double _currentItemValue;
    public double CurrentItemValue
    {
        get { return _currentItemValue; }
        set
        {
            if (SetProperty(ref _currentItemValue, value))
                OnPropertyChanged(nameof(Info));
        }
    }

    public NutrientModel(string name, double nutrientValue, ISettingsService settingsService)
    {
        Name = name;
        foodItemValue = nutrientValue;
        unit = settingsService.GetNutritionUnit(name);
        nutritionAmountNeeded = settingsService.GetNutritionNeed(name);
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