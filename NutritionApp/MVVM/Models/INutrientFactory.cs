namespace NutritionApp.MVVM.Models;

public interface INutrientFactory
{
    NutrientModel CreateNutrient(string name, double foodValue = 0, string customName = "", int roundingAmount = 0);
}
