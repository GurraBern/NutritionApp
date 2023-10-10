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
    private double _currentItemValue;
    public double CurrentItemValue
    {
        get { return _currentItemValue; }
        set
        {
            if (SetProperty(ref _currentItemValue, value))
                OnPropertyChanged(nameof(Title));
        }
    }

    public string Name { get; }
    public string unit = string.Empty;
    public string Title => $"{Name} {Math.Round(CurrentItemValue, 2)} {unit}";

    public Nutrient(string name, double amount, double foodItemValue, string unit, ISettingsService settingsService)
    {
        Name = name;
        nutritionAmount = amount;
        this.foodItemValue = foodItemValue;
        this.unit = unit;

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