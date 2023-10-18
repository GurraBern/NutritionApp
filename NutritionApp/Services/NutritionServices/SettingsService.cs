namespace NutritionApp.Services.NutritionServices;

public class SettingsService : ISettingsService
{
    private Dictionary<string, double> NutrientNeeds { get; } = new()
    {
        { "Calories", 2400 }, //kcal
        { "Protein", 110 }, //g
        { "Carbohydrates", 240 }, //g
        { "Fiber", 35 }, //g
        { "Sugars", 30 }, //g
        { "Starch", 0 }, //g
        { "Fat", 70 }, //g
        { "TransFat", 2.2 }, //g //Bad nutrient
        { "MonounsaturatedFat", 40 }, //g
        { "PolyunsaturatedFat", 15 }, //g
        { "SaturatedFat", 19 }, //g
        { "Cholesterol", 300 }, //mg
        { "VitaminA", 2999997 }, //IU
        { "VitaminD",  49999.95}, //IU
        { "VitaminE", 15 }, //mg
        { "VitaminC", 90 }, //mg
        { "VitaminK1", 120000 }, //mcg
        { "VitaminK2", 250000 }, //mcg
        { "Thiamin", 1.2 }, //mg
        { "Riboflavin", 1.6 }, //mg
        { "Niacin", 16 }, //mg
        { "PantothenicAcid", 5 }, //mg
        { "VitaminB6", 1.3 }, //mg
        { "Biotin", 100 }, //mcg
        { "Folate", 400 }, //mcg
        { "VitaminB12", 2.4 }, //mcg
        { "Choline", 550 }, //mg
        { "FolicAcid", 400 }, // mcg
        { "CaroteneAlpha", 900 }, //mcg
        { "CaroteneBeta", 15000 }, //mcg
        { "CryptoxanthinBeta", 200000 }, //mcg // RecommendedDosageUnknown
        { "LuteinZeaxanthin", 10000 }, //mcg 
        { "Lycopene", 21000 }, //mcg
        { "Calcium", 1000 }, //mg
        { "Chromium", 35 }, //mcg
        { "Iron", 8 }, //mg
        { "Zinc", 11 }, //mg
        { "Sodium", 2.3 }, //mg
        { "Magnesium", 400 }, //mg
        { "Copper", 2 },//mg
        { "Fluoride", 4000 }, //mcg
        { "Iodine", 150 }, //mcg
        { "Manganese", 2.3 }, //mg
        { "Molybdenum", 45 }, //mcg
        { "Nickel", 70 }, //mcg
        { "Phosphorus", 700 }, //mg
        { "Potassium", 3400 }, //mg
        { "Phosphorous", 700 },//mg
        { "Selenium", 55 }, //mcg
        { "Alanine", 4 }, //g
        { "Arginine", 15 }, //g
        { "Asparagine", 5 }, //g
        { "AsparticAcid", 3 }, //g
        { "Cystine", 0.5 }, //g
        { "GlutamicAcid", 15 }, //g
        { "Glutamine", 6 }, //g
        { "Glycine", 4 }, //g
        { "Histidine", 0.7 }, //g
        { "Isoleucine", 2.2 }, //g
        { "Leucine", 2.8 }, //g
        { "Lysine", 3 }, //g
        { "Methionine", 1 }, //g
        { "Phenylalanine", 2 }, //g
        { "Proline", 2 }, //g
        { "Serine", 8 }, //g
        { "Threonine", 1 }, //g
        { "Tryptophan", 1 }, //g
        { "Tyrosine", 1 }, //g
        { "Valine", 2 }, //g
        { "Theobromine", 0.450 }, //g
    };
    private Dictionary<string, string> NutrientUnit { get; } = new()
    {
        { "Calories", "kcal" },
        { "Protein", "g" },
        { "Carbohydrates", "g" },
        { "Fiber", "g" },
        { "Sugars", "g" },
        { "Starch", "g" },
        { "Fat", "g" },
        { "SaturatedFat", "g" },
        { "TransFat", "g" },
        { "MonounsaturatedFat", "g" },
        { "PolyunsaturatedFat", "g" },
        { "Cholesterol", "mg" },
        { "VitaminA", "IU" },
        { "Thiamin", "mg" },
        { "Riboflavin", "mg" },
        { "Niacin", "mg" },
        { "PantothenicAcid", "mg" },
        { "VitaminB6", "mg" },
        { "Biotin", "mcg" },
        { "Folate", "mcg" },
        { "VitaminB12", "mcg" },
        { "VitaminC", "mg" },
        { "Choline", "mg" },
        { "VitaminD", "IU" },
        { "VitaminE", "mg" },
        { "VitaminK1", "mcg" },
        { "VitaminK2", "mcg" },
        { "Calcium", "mg" },
        { "Chromium", "mcg" },
        { "Copper", "mg" },
        { "Fluoride", "mcg" },
        { "Iodine", "mcg" },
        { "Iron", "mg" },
        { "Magnesium", "mg" },
        { "Manganese", "mg" },
        { "Molybdenum", "mcg" },
        { "Nickel", "mcg" },
        { "Phosphorus", "mg" },
        { "Potassium", "mg" },
        { "Selenium", "mcg" },
        { "Sodium", "mg" },
        { "Zinc", "mg" },
        { "Alanine", "g" },
        { "Arginine", "g" },
        { "Asparagine", "g" },
        { "AsparticAcid", "g" },
        { "Cystine", "g" },
        { "GlutamicAcid", "g" },
        { "Glutamine", "g" },
        { "Glycine", "g" },
        { "Histidine", "g" },
        { "Isoleucine", "g" },
        { "Leucine", "g" },
        { "Lysine", "g" },
        { "Methionine", "g" },
        { "Phenylalanine", "g" },
        { "Proline", "g" },
        { "Serine", "g" },
        { "Threonine", "g" },
        { "Tryptophan", "g" },
        { "Tyrosine", "g" },
        { "Valine", "g" },
        { "CaroteneAlpha", "mcg" },
        { "CaroteneBeta", "mcg" },
        { "CryptoxanthinBeta", "mcg" },
        { "LuteinZeaxanthin", "mcg" },
        { "Lycopene", "mcg" },
        { "Theobromine", "g" }
    };

    public double GetNutritionNeed(string key)
    {
        return NutrientNeeds.TryGetValue(key, out var valueExist) ? valueExist : 0;
    }

    public string GetNutritionUnit(string key)
    {
        return NutrientUnit.TryGetValue(key, out var valueExist) ? valueExist : "";
    }
}
