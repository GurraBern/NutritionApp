namespace NutritionApp.MVVM.Viewmodels.Utils;

public class NutritionUtils
{
    public static readonly List<string> mainNutrients = new()
    {
         "Calories", "Carbohydrates", "Protein", "Fat"
    };

    public static readonly List<string> fats = new()
    {
        "Fat", "SaturatedFat", "Cholesterol", "TransFat", "MonounsaturatedFat", "PolyunsaturatedFat"
    };

    public static readonly List<string> vitamins = new()
    {
        "VitaminA", "VitaminC", "VitaminD", "VitaminE", "TocopherolAlpha", "VitaminK1", "VitaminK2", "Thiamin", "Riboflavin", "Niacin", "Choline",
        "PantothenicAcid", "VitaminB6", "Biotin", "Folate", "VitaminB12"
    };

    public static readonly List<string> macroMinerals = new()
    {
        "Calcium", "Sodium", "Iron", "Magnesium", "Potassium", "Zinc", "Selenium", "Iodine", "Copper", "Manganese",
        "Fluoride", "Chromium", "Molybdenum", "Nickel", "Phosphorous"
    };

    public static IEnumerable<string> DetailedAminoAcids => conditionallyEssentialAminoAcids.Concat(nonEssentialAminoAcids);

    public static readonly List<string> essentialAminoAcids = new()
    {
        "Histidine", "Isoleucine", "Leucine", "Lysine", "Methionine", "Phenylalanine", "Threonine", "Tryptophan", "Valine"
    };

    public static readonly List<string> conditionallyEssentialAminoAcids = new()
    {
        "Arginine", "Cystine", "Glutamine", "Glycine", "Proline", "Tyrosine"
    };

    public static readonly List<string> nonEssentialAminoAcids = new()
    {
        "Alanine", "AsparticAcid", "Asparagine", "GlutamicAcid", "Serine"
    };

    public static readonly List<string> other = new()
    {
        "CryptoxanthinBeta", "LuteinZeaxanthin", "Lycopene"
    };
}
