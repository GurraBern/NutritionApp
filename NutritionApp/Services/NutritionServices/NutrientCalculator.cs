using NutritionApp.MVVM.Models;

namespace NutritionApp.Services.NutritionServices;

public class NutrientCalculator
{
    public static void SumNutrients(FoodItem food, Dictionary<string, double> nutrients)
    {
        var amount = food.Amount;
        nutrients["Calories"] += CalculateNutrients(food.Calories, amount);
        nutrients["Protein"] += CalculateNutrients(food.Protein, amount);
        nutrients["Carbohydrates"] += CalculateNutrients(food.Carbohydrates.Carbohydrate, amount);
        nutrients["Fat"] += CalculateNutrients(food.Fats.Fat, amount);
        nutrients["SaturatedFat"] += CalculateNutrients(food.Fats.SaturatedFat, amount);
        nutrients["Cholesterol"] += CalculateNutrients(food.Fats.Cholesterol, amount);

        nutrients["VitaminA"] += CalculateNutrients(food.Vitamins.VitaminA, amount);
        nutrients["VitaminD"] += CalculateNutrients(food.Vitamins.VitaminD, amount);
        nutrients["VitaminE"] += CalculateNutrients(food.Vitamins.VitaminE, amount);
        nutrients["VitaminC"] += CalculateNutrients(food.Vitamins.VitaminC, amount);
        nutrients["VitaminK"] += CalculateNutrients(food.Vitamins.VitaminK, amount);
        nutrients["Thiamin"] += CalculateNutrients(food.Vitamins.Thiamin, amount);
        nutrients["Riboflavin"] += CalculateNutrients(food.Vitamins.Riboflavin, amount);
        nutrients["Niacin"] += CalculateNutrients(food.Vitamins.Niacin, amount);
        nutrients["PantothenicAcid"] += CalculateNutrients(food.Vitamins.PantothenicAcid, amount);
        nutrients["VitaminB6"] += CalculateNutrients(food.Vitamins.VitaminB6, amount);
        nutrients["Folate"] += CalculateNutrients(food.Vitamins.Folate, amount);
        nutrients["VitaminB12"] += CalculateNutrients(food.Vitamins.VitaminB12, amount);
        nutrients["TocopherolAlpha"] += CalculateNutrients(food.Vitamins.TocopherolAlpha, amount);
        nutrients["Choline"] += CalculateNutrients(food.Vitamins.Choline, amount);
        nutrients["FolicAcid"] += CalculateNutrients(food.Vitamins.FolicAcid, amount);
        nutrients["CaroteneAlpha"] += CalculateNutrients(food.Vitamins.CaroteneAlpha, amount);
        nutrients["CaroteneBeta"] += CalculateNutrients(food.Vitamins.CaroteneBeta, amount);
        nutrients["CryptoxanthinBeta"] += CalculateNutrients(food.Vitamins.CryptoxanthinBeta, amount);
        nutrients["LuteinZeaxanthin"] += CalculateNutrients(food.Vitamins.LuteinZeaxanthin, amount);
        nutrients["Lycopene"] += CalculateNutrients(food.Vitamins.Lycopene, amount);

        nutrients["Calcium"] += CalculateNutrients(food.Minerals.Calcium, amount);
        nutrients["Iron"] += CalculateNutrients(food.Minerals.Iron, amount);
        nutrients["Zink"] += CalculateNutrients(food.Minerals.Zink, amount);
        nutrients["Sodium"] += CalculateNutrients(food.Minerals.Sodium, amount);
        nutrients["Magnesium"] += CalculateNutrients(food.Minerals.Magnesium, amount);
        nutrients["Copper"] += CalculateNutrients(food.Minerals.Copper, amount);
        nutrients["Manganese"] += CalculateNutrients(food.Minerals.Manganese, amount);
        nutrients["Phosphorous"] += CalculateNutrients(food.Minerals.Phosphorous, amount);
        nutrients["Selenium"] += CalculateNutrients(food.Minerals.Selenium, amount);

        nutrients["Alanine"] += CalculateNutrients(food.AminoAcids.Alanine, amount);
        nutrients["Arginine"] += CalculateNutrients(food.AminoAcids.Arginine, amount);
        nutrients["AsparticAcid"] += CalculateNutrients(food.AminoAcids.AsparticAcid, amount);
        nutrients["Cystine"] += CalculateNutrients(food.AminoAcids.Cystine, amount);
        nutrients["GlutamicAcid"] += CalculateNutrients(food.AminoAcids.GlutamicAcid, amount);
        nutrients["Histidine"] += CalculateNutrients(food.AminoAcids.Histidine, amount);
        nutrients["Hydroxyproline"] += CalculateNutrients(food.AminoAcids.Hydroxyproline, amount);
        nutrients["Isoleucine"] += CalculateNutrients(food.AminoAcids.Isoleucine, amount);
        nutrients["Leucine"] += CalculateNutrients(food.AminoAcids.Leucine, amount);
        nutrients["Lysine"] += CalculateNutrients(food.AminoAcids.Lysine, amount);
        nutrients["Methionine"] += CalculateNutrients(food.AminoAcids.Methionine, amount);
        nutrients["Phenylalanine"] += CalculateNutrients(food.AminoAcids.Phenylalanine, amount);
        nutrients["Proline"] += CalculateNutrients(food.AminoAcids.Proline, amount);
        nutrients["Serine"] += CalculateNutrients(food.AminoAcids.Serine, amount);
        nutrients["Threonine"] += CalculateNutrients(food.AminoAcids.Threonine, amount);
        nutrients["Tryptophan"] += CalculateNutrients(food.AminoAcids.Tryptophan, amount);
        nutrients["Tyrosine"] += CalculateNutrients(food.AminoAcids.Tyrosine, amount);
        nutrients["Valine"] += CalculateNutrients(food.AminoAcids.Valine, amount);
    }

    private static double CalculateNutrients(double nutrient, int amount) => nutrient / 100 * amount;
}
