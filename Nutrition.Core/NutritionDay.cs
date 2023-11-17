using Google.Cloud.Firestore;

namespace Nutrition.Core;

[FirestoreData]
public class NutritionDay
{
    [FirestoreProperty]
    public string Date { get; set; } = DateTime.UtcNow.ToString("yyyy-MM-dd");

    [FirestoreProperty]
    public List<FoodItem> BreakfastFoods { get; set; } = new();

    [FirestoreProperty]
    public List<FoodItem> LunchFoods { get; set; } = new();

    [FirestoreProperty]
    public List<FoodItem> DinnerFoods { get; set; } = new();

    [FirestoreProperty]
    public List<FoodItem> SnacksFoods { get; set; } = new();

    [FirestoreProperty]
    public Dictionary<string, double> NutrientTotals { get; set; } = new()
    {
        { "Calories", 0 },
        { "Protein", 0 },
        { "Carbohydrates", 0 },
        { "Fiber", 0 },
        { "Sugars", 0 },
        { "Starch", 0 },
        { "Fat", 0 },
        { "SaturatedFat", 0 },
        { "TransFat", 0 },
        { "MonounsaturatedFat", 0 },
        { "PolyunsaturatedFat", 0 },
        { "Cholesterol", 0 },
        { "VitaminA", 0 },
        { "VitaminD", 0 },
        { "VitaminE", 0 },
        { "VitaminC", 0 },
        { "VitaminK1", 0 },
        { "VitaminK2", 0 },
        { "Thiamin", 0 },
        { "Riboflavin", 0 },
        { "Niacin", 0 },
        { "PantothenicAcid", 0 },
        { "VitaminB6", 0 },
        { "Biotin", 0 },
        { "Folate", 0 },
        { "VitaminB12", 0 },
        { "TocopherolAlpha", 0 },
        { "Choline", 0 },
        { "FolicAcid", 0 },
        { "CaroteneAlpha", 0 },
        { "CaroteneBeta", 0 },
        { "CryptoxanthinBeta", 0 }, // RecommendedDosageUnknown
        { "LuteinZeaxanthin", 0 },
        { "Lycopene", 0 },
        { "Calcium", 0 },
        { "Chromium", 0 },
        { "Iron", 0 },
        { "Zinc", 0 },
        { "Sodium", 0 },
        { "Magnesium", 0 },
        { "Copper", 0 },
        { "Fluoride", 0 },
        { "Iodine", 0 },
        { "Molybdenum", 0 },
        { "Nickel", 0 },
        { "Phosphorus", 0 },
        { "Potassium", 0 },
        { "Manganese", 0 },
        { "Phosphorous", 0 },
        { "Selenium", 0 },
        { "Alanine", 0 },
        { "Arginine", 0 },
        { "Asparagine", 0 },
        { "AsparticAcid", 0 },
        { "Cystine", 0 },
        { "GlutamicAcid", 0 },
        { "Glutamine", 0 },
        { "Glycine", 0 },
        { "Histidine", 0 },
        { "Hydroxyproline", 0 }, // RecommendedDosageUnknown
        { "Isoleucine", 0 },
        { "Leucine", 0 },
        { "Lysine", 0 },
        { "Methionine", 0 },
        { "Phenylalanine", 0 },
        { "Proline", 0 },
        { "Serine", 0 },
        { "Threonine", 0 },
        { "Tryptophan", 0 },
        { "Tyrosine", 0 },
        { "Valine", 0 },
        { "Theobromine", 0 }
    };

    public NutritionDay()
    {

    }

    public void AddFood(FoodItem food)
    {
        AddFoodToMeal(food);
        SumNutrients(food, NutrientTotals);
    }

    private void AddFoodToMeal(FoodItem food)
    {
        var mealOfDay = (food.MealOfDay == MealOfDay.NoClassification) ? GetMealOfDay() : food.MealOfDay;
        switch (mealOfDay)
        {
            case MealOfDay.Breakfast:
                BreakfastFoods.Add(food);
                break;
            case MealOfDay.Lunch:
                LunchFoods.Add(food);
                break;
            case MealOfDay.Dinner:
                DinnerFoods.Add(food);
                break;
            case MealOfDay.Snacks:
                SnacksFoods.Add(food);
                break;
        }
    }

    private static MealOfDay GetMealOfDay()
    {
        var currentTime = DateTime.Now.TimeOfDay;

        if (IsBetween(currentTime, new TimeSpan(5, 0, 0), new TimeSpan(10, 30, 0)))
            return MealOfDay.Breakfast;
        else if (IsBetween(currentTime, new TimeSpan(11, 0, 0), new TimeSpan(14, 0, 0)))
            return MealOfDay.Lunch;
        else if (IsBetween(currentTime, new TimeSpan(17, 0, 0), new TimeSpan(20, 0, 0)))
            return MealOfDay.Dinner;

        return MealOfDay.Snacks;
    }

    private static bool IsBetween(TimeSpan time, TimeSpan start, TimeSpan end)
    {
        if (start <= end)
        {
            return start <= time && time <= end;
        }
        else
        {
            return start <= time || time <= end;
        }
    }

    private static void SumNutrients(FoodItem food, Dictionary<string, double> nutrients)
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
