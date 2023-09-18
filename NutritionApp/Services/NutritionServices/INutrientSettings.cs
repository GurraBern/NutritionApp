namespace NutritionApp.Services.NutritionServices;

public interface INutrientSettings
{
    public Dictionary<string, double> NutrientNeeds { get; set; }
}