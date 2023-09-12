using CommunityToolkit.Mvvm.Input;
using NutritionApp.MVVM.Models;
using NutritionApp.Services;

namespace NutritionApp.MVVM.ViewModels;

public partial class FoodDetailViewModel : BaseViewModel
{
    private readonly INutritionTracker nutritionTracker;
    private int amount = 100;
    public FoodItem FoodItem { get; }
    public double PotentialKcalProgress => CalculateProgress(nutritionTracker.TotalKcal, FoodItem.Calories, 2400);
    public double KcalProgress => nutritionTracker.TotalKcal / 2400;
    public double PotentialProteinProgress => CalculateProgress(nutritionTracker.TotalProtein, FoodItem.Protein, 110);
    public double ProteinProgress => nutritionTracker.TotalProtein / 110;
    public double PotentialCarbsProgress => CalculateProgress(nutritionTracker.TotalCarbs, FoodItem.Carbohydrates.Carbohydrate, 240);
    public double CarbsProgress => nutritionTracker.TotalCarbs / 240;
    public double PotentialFatProgress => CalculateProgress(nutritionTracker.TotalFat, FoodItem.Fats.TotalFat, 70);
    public double FatProgress => nutritionTracker.TotalFat / 70;
    public double KcalAmount => CalculateCurrentAmount(FoodItem.Calories);
    public double ProteinAmount => CalculateCurrentAmount(FoodItem.Protein);
    public double CarbsAmount => CalculateCurrentAmount(FoodItem.Carbohydrates.Carbohydrate);
    public double FatAmount => CalculateCurrentAmount(FoodItem.Fats.Fat);
    public double VitaminAAmount => CalculateCurrentAmount(FoodItem.Vitamins.VitaminA);
    public double VitaminDAmount => CalculateCurrentAmount(FoodItem.Vitamins.VitaminD);
    public double VitaminEAmount => CalculateCurrentAmount(FoodItem.Vitamins.VitaminE);
    public double VitaminCAmount => CalculateCurrentAmount(FoodItem.Vitamins.VitaminC);
    public double VitaminKAmount => CalculateCurrentAmount(FoodItem.Vitamins.VitaminK);
    public double VitaminB1Amount => CalculateCurrentAmount(FoodItem.Vitamins.Thiamin);

    public double VitaminAProgress => CalculateProgress(nutritionTracker.TotalVitaminA, FoodItem.Vitamins.VitaminA, 1);


    public int Amount
    {
        get => amount;
        set
        {
            if (amount != value)
            {
                amount = value;

                UpdateAllOnPropertiesChanged();
            }
        }
    }

    public FoodDetailViewModel(FoodItem foodItem, INutritionTracker nutritionTracker)
    {
        FoodItem = foodItem;
        this.nutritionTracker = nutritionTracker;
    }

    [RelayCommand]
    public async Task AddFood()
    {
        nutritionTracker.AddFood(FoodItem);

        await Shell.Current.GoToAsync("//MainPage");
    }

    private double CalculateProgress(double currentValue, double foodItemValue, double targetValue) =>
        (currentValue + amount * foodItemValue / 100) / targetValue;

    private double CalculateCurrentAmount(double nutritionAmount)
    {
        var test = Math.Round(nutritionAmount / 100 * Amount, 2);

        return test;
    }

    private void UpdateAllOnPropertiesChanged()
    {
        OnPropertyChanged(nameof(Amount));
        OnPropertyChanged(nameof(PotentialKcalProgress));
        OnPropertyChanged(nameof(KcalProgress));
        OnPropertyChanged(nameof(ProteinProgress));
        OnPropertyChanged(nameof(PotentialProteinProgress));
        OnPropertyChanged(nameof(CarbsProgress));
        OnPropertyChanged(nameof(PotentialCarbsProgress));
        OnPropertyChanged(nameof(FatProgress));
        OnPropertyChanged(nameof(PotentialFatProgress));
        OnPropertyChanged(nameof(KcalAmount));
        OnPropertyChanged(nameof(ProteinAmount));
        OnPropertyChanged(nameof(CarbsAmount));
        OnPropertyChanged(nameof(FatAmount));
        OnPropertyChanged(nameof(VitaminAAmount));
        OnPropertyChanged(nameof(VitaminDAmount));
        OnPropertyChanged(nameof(VitaminEAmount));
        OnPropertyChanged(nameof(VitaminCAmount));
        OnPropertyChanged(nameof(VitaminKAmount));
        OnPropertyChanged(nameof(VitaminB1Amount));
    }
}
