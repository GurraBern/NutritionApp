namespace NutritionApp.Services.NutritionServices;

public interface ISettingsService
{
    double GetNutritionNeed(string key);
    string GetNutritionUnit(string key);
}