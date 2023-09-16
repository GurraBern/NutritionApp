namespace NutritionApp.Services.NutritionServices;

public interface INutrientSettings
{
    public double KcalNeeded { get; }
    public double ProteinNeeded { get; }
    public double CarbsNeeded { get; }
    public double FatNeeded { get; }
    public double SaturatedFatNeeded { get; }
    public double CholesterolNeeded { get; }
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
    public double CaroteneBetaNeeded { get; }
    public double CryptoxanthinBetaNeeded { get; }
    public double LuteinZeaxanthinNeeded { get; }
    public double LycopeneNeeded { get; }
    public double CalciumNeeded { get; }
    public double IronNeeded { get; }
    public double ZinkNeeded { get; }
    public double SodiumNeeded { get; }
    public double MagnesiumNeeded { get; }
    public double CopperNeeded { get; }
    public double ManganeseNeeded { get; }
    public double PhosphorousNeeded { get; }
    public double SeleniumNeeded { get; }
}