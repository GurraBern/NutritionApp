using NutritionTrackR.Contracts.Food;

namespace NutritionTrackR.Web.Shared.Nutrition;

public static class Nutrients
{
    public static NutrientDto Calories => new NutrientDto { Name = "Calories", Unit = nameof(Unit.Kcal), Weight = 0 };
    public static NutrientDto Protein => new NutrientDto { Name = "Protein", Unit = nameof(Unit.Grams), Weight = 0 };
    public static NutrientDto Carbohydrates => new NutrientDto { Name = "Carbohydrates", Unit = nameof(Unit.Grams), Weight = 0 };
    public static NutrientDto Fiber => new NutrientDto { Name = "Fiber", Unit = nameof(Unit.Grams), Weight = 0 };
    public static NutrientDto Sugars => new NutrientDto { Name = "Sugars", Unit = nameof(Unit.Grams), Weight = 0 };
    public static NutrientDto Starch => new NutrientDto { Name = "Starch", Unit = nameof(Unit.Grams), Weight = 0 };

    public static NutrientDto Fat => new NutrientDto { Name = "Total Fat", Unit = nameof(Unit.Grams), Weight = 0 };
    public static NutrientDto SaturatedFat => new NutrientDto { Name = "SaturatedFat", Unit = nameof(Unit.Grams), Weight = 0 };
    public static NutrientDto TransFat => new NutrientDto { Name = "TransFat", Unit = nameof(Unit.Grams), Weight = 0 };
    public static NutrientDto MonounsaturatedFat => new NutrientDto { Name = "MonounsaturatedFat", Unit = nameof(Unit.Grams), Weight = 0 };
    public static NutrientDto PolyunsaturatedFat => new NutrientDto { Name = "PolyunsaturatedFat", Unit = nameof(Unit.Grams), Weight = 0 };
    public static NutrientDto Cholesterol => new NutrientDto { Name = "Cholesterol", Unit = nameof(Unit.Grams), Weight = 0 };
    public static NutrientDto Omega3 => new NutrientDto { Name = "Omega 3", Unit = nameof(Unit.Grams), Weight = 0 };
    public static NutrientDto Omega6 => new NutrientDto { Name = "Omega 6", Unit = nameof(Unit.Grams), Weight = 0 };

    // Vitamins
    public static NutrientDto VitaminA => new NutrientDto { Name = "Vitamin A", Unit = nameof(Unit.Microgram), Weight = 0 };
    public static NutrientDto VitaminC => new NutrientDto { Name = "Vitamin C", Unit = nameof(Unit.Milligram), Weight = 0 };
    public static NutrientDto VitaminD => new NutrientDto { Name = "Vitamin D", Unit = nameof(Unit.Microgram), Weight = 0 };
    public static NutrientDto VitaminB6 => new NutrientDto { Name = "Vitamin B6", Unit = nameof(Unit.Milligram), Weight = 0 };
    public static NutrientDto VitaminE => new NutrientDto { Name = "Vitamin E", Unit = nameof(Unit.Milligram), Weight = 0 };
    public static NutrientDto VitaminK1 => new NutrientDto { Name = "Vitamin K1", Unit = nameof(Unit.Microgram), Weight = 0 };
    public static NutrientDto VitaminK2 => new NutrientDto { Name = "Vitamin K2", Unit = nameof(Unit.Grams), Weight = 0 };
    public static NutrientDto Thiamin => new NutrientDto { Name = "Thiamin", Unit = nameof(Unit.Milligram), Weight = 0 };
    public static NutrientDto Riboflavin => new NutrientDto { Name = "Riboflavin", Unit = nameof(Unit.Milligram), Weight = 0 };
    public static NutrientDto Niacin => new NutrientDto { Name = "Niacin", Unit = nameof(Unit.Milligram), Weight = 0 };
    public static NutrientDto PantothenicAcid => new NutrientDto { Name = "Pantothenic Acid", Unit = nameof(Unit.Milligram), Weight = 0 };
    public static NutrientDto Biotin => new NutrientDto { Name = "Biotin", Unit = nameof(Unit.Microgram), Weight = 0 };
    public static NutrientDto Folate => new NutrientDto { Name = "Folate", Unit = nameof(Unit.Microgram), Weight = 0 };
    public static NutrientDto VitaminB12 => new NutrientDto { Name = "Vitamin B12", Unit = nameof(Unit.Microgram), Weight = 0 };
    public static NutrientDto TocopherolAlpha => new NutrientDto { Name = "Tocopherol Alpha", Unit = nameof(Unit.Grams), Weight = 0 };
    public static NutrientDto Choline => new NutrientDto { Name = "Choline", Unit = nameof(Unit.Grams), Weight = 0 };
    public static NutrientDto FolicAcid => new NutrientDto { Name = "Folic Acid", Unit = nameof(Unit.Grams), Weight = 0 };
    public static NutrientDto CaroteneAlpha => new NutrientDto { Name = "Carotene Alpha", Unit = nameof(Unit.Grams), Weight = 0 };
    public static NutrientDto CaroteneBeta => new NutrientDto { Name = "Carotene Beta", Unit = nameof(Unit.Grams), Weight = 0 };
    public static NutrientDto CryptoxanthinBeta => new NutrientDto { Name = "Cryptoxanthin Beta", Unit = nameof(Unit.Grams), Weight = 0 };
    public static NutrientDto LuteinZeaxanthin => new NutrientDto { Name = "Lutein Zeaxanthin", Unit = nameof(Unit.Grams), Weight = 0 };
    public static NutrientDto Lycopene => new NutrientDto { Name = "Lycopene", Unit = nameof(Unit.Grams), Weight = 0 };

    // Minerals
    public static NutrientDto Calcium => new NutrientDto { Name = "Calcium", Unit = nameof(Unit.Milligram), Weight = 0 };
    public static NutrientDto Chloride => new NutrientDto { Name = "Chloride", Unit = nameof(Unit.Grams), Weight = 0 };
    public static NutrientDto Chromium => new NutrientDto { Name = "Chromium", Unit = nameof(Unit.Microgram), Weight = 0 };
    public static NutrientDto Iron => new NutrientDto { Name = "Iron", Unit = nameof(Unit.Milligram), Weight = 0 };
    public static NutrientDto Zinc => new NutrientDto { Name = "Zinc", Unit = nameof(Unit.Milligram), Weight = 0 };
    public static NutrientDto Sodium => new NutrientDto { Name = "Sodium", Unit = nameof(Unit.Milligram), Weight = 0 };
    public static NutrientDto Magnesium => new NutrientDto { Name = "Magnesium", Unit = nameof(Unit.Milligram), Weight = 0 };
    public static NutrientDto Copper => new NutrientDto { Name = "Copper", Unit = nameof(Unit.Microgram), Weight = 0 };
    public static NutrientDto Fluoride => new NutrientDto { Name = "Fluoride", Unit = nameof(Unit.Milligram), Weight = 0 };
    public static NutrientDto Iodine => new NutrientDto { Name = "Iodine", Unit = nameof(Unit.Microgram), Weight = 0 };
    public static NutrientDto Molybdenum => new NutrientDto { Name = "Molybdenum", Unit = nameof(Unit.Microgram), Weight = 0 };
    public static NutrientDto Nickel => new NutrientDto { Name = "Nickel", Unit = nameof(Unit.Milligram), Weight = 0 };
    public static NutrientDto Phosphorus => new NutrientDto { Name = "Phosphorus", Unit = nameof(Unit.Grams), Weight = 0 };
    public static NutrientDto Potassium => new NutrientDto { Name = "Potassium", Unit = nameof(Unit.Milligram), Weight = 0 };
    public static NutrientDto Manganese => new NutrientDto { Name = "Manganese", Unit = nameof(Unit.Milligram), Weight = 0 };
    public static NutrientDto Selenium => new NutrientDto { Name = "Selenium", Unit = nameof(Unit.Microgram), Weight = 0 };

    // Amino Acids
    public static NutrientDto Alanine => new NutrientDto { Name = "Alanine", Unit = nameof(Unit.Grams), Weight = 0 };
    public static NutrientDto Arginine => new NutrientDto { Name = "Arginine", Unit = nameof(Unit.Grams), Weight = 0 };
    public static NutrientDto Asparagine => new NutrientDto { Name = "Asparagine", Unit = nameof(Unit.Grams), Weight = 0 };
    public static NutrientDto AsparticAcid => new NutrientDto { Name = "Aspartic Acid", Unit = nameof(Unit.Grams), Weight = 0 };
    public static NutrientDto Cystine => new NutrientDto { Name = "Cystine", Unit = nameof(Unit.Grams), Weight = 0 };
    public static NutrientDto GlutamicAcid => new NutrientDto { Name = "Glutamic Acid", Unit = nameof(Unit.Grams), Weight = 0 };
    public static NutrientDto Glutamine => new NutrientDto { Name = "Glutamine", Unit = nameof(Unit.Grams), Weight = 0 };
    public static NutrientDto Glycine => new NutrientDto { Name = "Glycine", Unit = nameof(Unit.Grams), Weight = 0 };
    public static NutrientDto Histidine => new NutrientDto { Name = "Histidine", Unit = nameof(Unit.Milligram), Weight = 0 };
    public static NutrientDto Hydroxyproline => new NutrientDto { Name = "Hydroxyproline", Unit = nameof(Unit.Grams), Weight = 0 };
    public static NutrientDto Isoleucine => new NutrientDto { Name = "Isoleucine", Unit = nameof(Unit.Milligram), Weight = 0 };
    public static NutrientDto Leucine => new NutrientDto { Name = "Leucine", Unit = nameof(Unit.Milligram), Weight = 0 };
    public static NutrientDto Lysine => new NutrientDto { Name = "Lysine", Unit = nameof(Unit.Milligram), Weight = 0 };
    public static NutrientDto Methionine => new NutrientDto { Name = "Methionine", Unit = nameof(Unit.Milligram), Weight = 0 };
    public static NutrientDto Phenylalanine => new NutrientDto { Name = "Phenylalanine", Unit = nameof(Unit.Milligram), Weight = 0 };
    public static NutrientDto Proline => new NutrientDto { Name = "Proline", Unit = nameof(Unit.Grams), Weight = 0 };// Nonessential
    public static NutrientDto Serine => new NutrientDto { Name = "Serine", Unit = nameof(Unit.Grams), Weight = 0 };// Nonessential
    public static NutrientDto Threonine => new NutrientDto { Name = "Threonine", Unit = nameof(Unit.Milligram), Weight = 0 };
    public static NutrientDto Tryptophan => new NutrientDto { Name = "Tryptophan", Unit = nameof(Unit.Milligram), Weight = 0 };
    public static NutrientDto Tyrosine => new NutrientDto { Name = "Tyrosine", Unit = nameof(Unit.Grams), Weight = 0 };// Nonessential
    public static NutrientDto Valine => new NutrientDto { Name = "Valine", Unit = nameof(Unit.Milligram), Weight = 0 };

    public static List<NutrientDto> All =>
    [
        Calories, Protein, Carbohydrates, Fiber, Sugars, Starch, Fat, SaturatedFat, TransFat,
        MonounsaturatedFat, PolyunsaturatedFat, Cholesterol, Omega3, Omega6, VitaminA, VitaminC,
        VitaminD, VitaminB6, VitaminE, VitaminK1, VitaminK2, Thiamin, Riboflavin, Niacin,
        PantothenicAcid, Biotin, Folate, VitaminB12, TocopherolAlpha, Choline, FolicAcid,
        CaroteneAlpha, CaroteneBeta, CryptoxanthinBeta, LuteinZeaxanthin, Lycopene, Calcium,
        Chloride, Chromium, Iron, Zinc, Sodium, Magnesium, Copper, Fluoride, Iodine, Molybdenum,
        Nickel, Phosphorus, Potassium, Manganese, Selenium, Alanine, Arginine, Asparagine, AsparticAcid,
        Cystine, GlutamicAcid, Glutamine, Glycine, Histidine, Hydroxyproline, Isoleucine, Leucine, Lysine,
        Methionine, Phenylalanine, Proline, Serine, Threonine, Tryptophan, Tyrosine, Valine
    ];
}