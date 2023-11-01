using NutritionApp.Services.NutritionServices;

namespace NutritionApp.MVVM.Models;

public class NutrientFactory : INutrientFactory
{
    private readonly ISettingsService settingsService;

    public NutrientFactory(ISettingsService settingsService)
    {
        this.settingsService = settingsService;
    }

    public Nutrient CreateNutrient(string name, double foodValue, string customName)
    {
        var nutrient = new Nutrient(name, foodValue, settingsService)
        {
            CustomName = customName,
        };

        return nutrient;
    }
}
