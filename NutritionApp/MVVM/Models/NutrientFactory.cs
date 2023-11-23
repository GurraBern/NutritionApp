using NutritionApp.Services.NutritionServices;

namespace NutritionApp.MVVM.Models;

public class NutrientFactory : INutrientFactory
{
    private readonly ISettingsService settingsService;

    public NutrientFactory(ISettingsService settingsService)
    {
        this.settingsService = settingsService;
    }

    public NutrientModel CreateNutrient(string name, double foodValue)
    {
        var neededNutrient = settingsService.GetNutrientNeed(name);
        var nutrient = new NutrientModel(neededNutrient, foodValue);

        return nutrient;
    }
}
