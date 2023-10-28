namespace NutritionApp.MVVM.Models;

public interface INutrientFactory
{
    Nutrient CreateNutrient(string name, double foodValue = 0, string customName = "");
}
