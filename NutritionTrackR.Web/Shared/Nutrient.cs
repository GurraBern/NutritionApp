namespace NutritionTrackR.Web.Shared;

public class Nutrient
{
    
    public string Name { get; set; } = string.Empty;

    public double Weight { get; set; }

    public Unit Unit { get; set; }

    public string DisplayWeight() => $"{Math.Round(Weight, 2)} {Unit}";
}
