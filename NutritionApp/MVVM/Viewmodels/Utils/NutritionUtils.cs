namespace NutritionApp.MVVM.Viewmodels.Utils;

public class NutritionUtils
{
    public static readonly List<string> mainNutrients = new()
    {
        "Calories", "Protein", "Carbohydrates", "Fat", "SaturatedFat", "Cholesterol"
    };

    public static readonly List<string> vitamins = new()
    {
        "VitaminA", "VitaminD", "VitaminE", "VitaminC", "VitaminK", "Thiamin", "Riboflavin", "Niacin",
        "PantothenicAcid", "VitaminB6", "Folate", "VitaminB12", "TocopherolAlpha", "Choline", "FolicAcid",
        "CaroteneAlpha", "CaroteneBeta", "CryptoxanthinBeta", "LuteinZeaxanthin", "Lycopene"
    };

    public static readonly List<string> minerals = new()
    {
        "Calcium", "Iron", "Zink", "Sodium", "Sodium", "Magnesium", "Copper", "Manganese", "Phosphorous", "Selenium",
    };

    public static readonly List<string> aminoAcids = new()
    {
        "Alanine", "Arginine", "AsparticAcid", "Cystine", "GlutamicAcid", "Histidine", "Hydroxyproline", "Isoleucine",
        "Leucine", "Lysine", "Methionine", "Phenylalanine", "Proline", "Serine", "Threonine", "Tryptophan", "Tyrosine",
        "Valine",
    };
}
