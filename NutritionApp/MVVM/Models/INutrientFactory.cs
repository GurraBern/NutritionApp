namespace NutritionApp.MVVM.Models;

public interface INutrientFactory
{
    Nutrient CreateNutrient(string name, int amount = 0, double foodValue = 0);
}
