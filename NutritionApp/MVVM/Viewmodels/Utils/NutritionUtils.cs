namespace NutritionApp.MVVM.Viewmodels.Utils;

public class NutritionUtils
{
    public static readonly List<string> mainNutrients = new()
    {
        "Calories", "Protein", "Carbohydrates", "Fat", "SaturatedFat", "Cholesterol"
    };

    public static readonly List<string> vitamins = new()
    {
        "VitaminA", "VitaminD", "VitaminE", "VitaminC", "VitaminK1", "VitaminK2", "Thiamin", "Riboflavin", "Niacin",
        "PantothenicAcid", "VitaminB6", "Folate", "VitaminB12", "TocopherolAlpha", "Choline", "FolicAcid",
        "CaroteneAlpha", "CaroteneBeta", "CryptoxanthinBeta", "LuteinZeaxanthin", "Lycopene"
    };

    public static readonly List<string> minerals = new()
    {
        "Calcium", "Iron", "Zinc", "Sodium", "Sodium", "Magnesium", "Copper", "Manganese", "Phosphorous", "Selenium",
        "Iodine", "Fluoride","Molybdenum", "Nickel", "Phosphorus", "Potassium"
    };

    public static readonly List<string> aminoAcids = new()
    {
        "Alanine", "Arginine", "Asparagine", "AsparticAcid", "Cystine", "GlutamicAcid", "Glutamine", "Glycine",
        "Histidine", "Hydroxyproline", "Isoleucine", "Leucine", "Lysine", "Methionine", "Phenylalanine",
        "Proline", "Serine", "Threonine", "Tryptophan", "Tyrosine", "Valine", "Theobromine"
    };
}
