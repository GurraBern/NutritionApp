using NutritionApp.Services.NutritionServices;

namespace NutritionApp.MVVM.Models;

public class NutrientFactory(ISettingsService settingsService) : INutrientFactory
{
    public NutrientModel CreateNutrient(string name, double foodValue)
    {
        var neededNutrient = settingsService.GetNutrientNeed(name);
        var nutrient = new NutrientModel(neededNutrient, foodValue);

        return nutrient;
    }
}
