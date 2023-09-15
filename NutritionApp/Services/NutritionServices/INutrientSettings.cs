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
    public double ThiaminNeeded { get; }
    public double RiboflavinNeeded { get; }
    public double NiacinNeeded { get; }
    public double PantothenicAcidNeeded { get; }
    public double VitaminB6Needed { get; }
    public double FolateNeeded { get; }
    public double VitaminB12Needed { get; }
    public double TocopherolAlphaNeeded { get; }
    public double CholineNeeded { get; }
    public double FolicAcidNeeded { get; }
    public double CaroteneAlphaNeeded { get; }

    

}