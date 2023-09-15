namespace NutritionApp.Services.NutritionServices;

public class NutrientSettings : INutrientSettings
{
    public double KcalNeeded => 2400;

    public double ProteinNeeded => 110;

    public double CarbsNeeded => 240;

    public double FatNeeded => 70;

    public double VitaminANeeded => 0.0009;

    public double VitaminDNeeded => 0.000015;

    public double VitaminENeeded => 0.00159;

    public double VitaminCNeeded => 0.075;

    public double VitaminKNeeded => 0.00012;

    public double ThiaminNeeded => 0.0012;

    public double RiboflavinNeeded => 0.0013;

    public double NiacinNeeded => 0.016;

    public double PantothenicAcidNeeded => throw new NotImplementedException();

    public double VitaminB6Needed => throw new NotImplementedException();

    public double FolateNeeded => throw new NotImplementedException();

    public double VitaminB12Needed => throw new NotImplementedException();

    public double TocopherolAlphaNeeded => throw new NotImplementedException();

    public double CholineNeeded => throw new NotImplementedException();

    public double FolicAcidNeeded => throw new NotImplementedException();

    public double CaroteneAlphaNeeded => throw new NotImplementedException();
}
