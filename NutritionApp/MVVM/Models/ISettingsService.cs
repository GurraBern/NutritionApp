namespace NutritionApp.MVVM.Models;

public interface ISettingsService
{
    double GetNutritionNeed(string key);
    string GetNutritionUnit(string key);
}