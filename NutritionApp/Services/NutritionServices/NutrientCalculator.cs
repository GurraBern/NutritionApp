using NutritionApp.MVVM.Models;

namespace NutritionApp.Services.NutritionServices;

public class NutrientCalculator
{



    public static void SumNutrients(FoodItem food, Dictionary<string, double> nutrients)
    {
        var amount = food.Amount;
        nutrients["Calories"] += CalculateNutrients(food.Calories, amount);
        nutrients["Protein"] += CalculateNutrients(food.Protein, amount);
        nutrients["Carbohydrates"] += CalculateNutrients(food.Carbohydrate, amount);
        nutrients["Fat"] += CalculateNutrients(food.TotalFat, amount);
        nutrients["SaturatedFat"] += CalculateNutrients(food.TotalSaturatedFat, amount);
        nutrients["TransFat"] += CalculateNutrients(food.TotalTransFat, amount);
        nutrients["MonounsaturatedFat"] += CalculateNutrients(food.TotalMonounsaturated, amount);
        nutrients["PolyunsaturatedFat"] += CalculateNutrients(food.TotalPolyunsaturated, amount);
        nutrients["Cholesterol"] += CalculateNutrients(food.Cholesterol, amount);

        nutrients["VitaminA"] += CalculateNutrients(food.VitaminA, amount);
        nutrients["Thiamin"] += CalculateNutrients(food.Thiamin, amount);
        nutrients["Riboflavin"] += CalculateNutrients(food.Riboflavin, amount);
        nutrients["Niacin"] += CalculateNutrients(food.Niacin, amount);
        nutrients["PantothenicAcid"] += CalculateNutrients(food.PantothenicAcid, amount);
        nutrients["VitaminB6"] += CalculateNutrients(food.VitaminB6, amount);
        nutrients["Biotin"] += CalculateNutrients(food.Biotin, amount);
        nutrients["Folate"] += CalculateNutrients(food.Folate, amount);
        nutrients["VitaminB12"] += CalculateNutrients(food.VitaminB12, amount);
        nutrients["VitaminC"] += CalculateNutrients(food.VitaminC, amount);
        nutrients["Choline"] += CalculateNutrients(food.Choline, amount);
        nutrients["VitaminD"] += CalculateNutrients(food.VitaminD, amount);
        nutrients["VitaminE"] += CalculateNutrients(food.VitaminE, amount);
        nutrients["VitaminK1"] += CalculateNutrients(food.VitaminK1, amount);
        nutrients["VitaminK2"] += CalculateNutrients(food.VitaminK2, amount);

        nutrients["Calcium"] += CalculateNutrients(food.Calcium, amount);
        nutrients["Chromium"] += CalculateNutrients(food.Chromium, amount);
        nutrients["Copper"] += CalculateNutrients(food.Copper, amount);
        nutrients["Iron"] += CalculateNutrients(food.Iron, amount);
        nutrients["Magnesium"] += CalculateNutrients(food.Magnesium, amount);
        nutrients["Manganese"] += CalculateNutrients(food.Manganese, amount);
        nutrients["Molybdenum"] += CalculateNutrients(food.Molybdenum, amount);
        nutrients["Nickel"] += CalculateNutrients(food.Nickel, amount);
        nutrients["Phosphorus"] += CalculateNutrients(food.Phosphorus, amount);
        nutrients["Selenium"] += CalculateNutrients(food.Selenium, amount);
        nutrients["Sodium"] += CalculateNutrients(food.Sodium, amount);
        nutrients["Zinc"] += CalculateNutrients(food.Zinc, amount);

        nutrients["Alanine"] += CalculateNutrients(food.Alanine, amount);
        nutrients["Arginine"] += CalculateNutrients(food.Arginine, amount);
        nutrients["Asparagine"] += CalculateNutrients(food.Asparagine, amount);
        nutrients["AsparticAcid"] += CalculateNutrients(food.AsparticAcid, amount);
        nutrients["Cystine"] += CalculateNutrients(food.Cystine, amount);
        nutrients["GlutamicAcid"] += CalculateNutrients(food.GlutamicAcid, amount);
        nutrients["Glutamine"] += CalculateNutrients(food.Glutamine, amount);
        nutrients["Glycine"] += CalculateNutrients(food.Glycine, amount);
        nutrients["Histidine"] += CalculateNutrients(food.Histidine, amount);
        nutrients["Isoleucine"] += CalculateNutrients(food.Isoleucine, amount);
        nutrients["Leucine"] += CalculateNutrients(food.Leucine, amount);
        nutrients["Lysine"] += CalculateNutrients(food.Lysine, amount);
        nutrients["Methionine"] += CalculateNutrients(food.Methionine, amount);
        nutrients["Phenylalanine"] += CalculateNutrients(food.Phenylalanine, amount);
        nutrients["Proline"] += CalculateNutrients(food.Proline, amount);
        nutrients["Serine"] += CalculateNutrients(food.Serine, amount);
        nutrients["Threonine"] += CalculateNutrients(food.Threonine, amount);
        nutrients["Tryptophan"] += CalculateNutrients(food.Tryptophan, amount);
        nutrients["Tyrosine"] += CalculateNutrients(food.Tyrosine, amount);
        nutrients["Valine"] += CalculateNutrients(food.Valine, amount);

        nutrients["CaroteneAlpha"] += CalculateNutrients(food.CaroteneAlpha, amount);
        nutrients["CaroteneBeta"] += CalculateNutrients(food.CaroteneBeta, amount);
        nutrients["CryptoxanthinBeta"] += CalculateNutrients(food.CryptoxanthinBeta, amount);
        nutrients["LuteinZeaxanthin"] += CalculateNutrients(food.LuteinZeaxanthin, amount);
        nutrients["Lycopene"] += CalculateNutrients(food.Lycopene, amount);
        nutrients["Theobromine"] += CalculateNutrients(food.Theobromine, amount);
    }

    private static double CalculateNutrients(double nutrient, int amount) => nutrient / 100 * amount;
}
