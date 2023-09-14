namespace NutritionApp.Services.NutritionServices;

public interface INutrientSettings
{
    public double KcalNeeded { get; }
    public double ProteinNeeded { get; }
    public double CarbsNeeded { get; }
    public double FatNeeded { get; }
    public double VitaminANeeded { get; }
    public double VitaminDNeeded { get; }
    public double VitaminENeeded { get; }
    public double VitaminCNeeded { get; }
    public double VitaminKNeeded { get; }
}