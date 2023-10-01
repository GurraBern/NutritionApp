namespace NutritionApp.MVVM.Models;

public class NutrientFactory : INutrientFactory
{
    private readonly ISettingsService settingsService;

    public NutrientFactory(ISettingsService settingsService)
    {
        this.settingsService = settingsService;
    }

    public Nutrient CreateNutrient(string name, int amount, double foodValue)
    {
        return new Nutrient(name, amount, foodValue, settingsService);
    }
}
