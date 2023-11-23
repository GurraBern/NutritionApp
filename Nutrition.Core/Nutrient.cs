namespace Nutrition.Core;

public class Nutrient
{
    public string NutrientName { get; set; }
    public string Unit { get; set; }
    public double Amount { get; set; }

    public Nutrient(string nutrientName, string unit, double amount)
    {
        NutrientName = nutrientName;
        Unit = unit;
        Amount = amount;
    }
}
