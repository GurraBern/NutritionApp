using Newtonsoft.Json;
using Nutrition.Core;
using NutritionApp.MVVM.Models;

namespace NutritionApp.Services.NutritionServices;

public class SettingsService : ISettingsService
{
    private Dictionary<string, Nutrient> NutrientNeeds { get; } = new()
    {
        { "Calories", new Nutrient("Calories", "kcal", 2400) },
        { "Protein", new Nutrient("Protein", "g", 110) },
        { "Carbohydrates", new Nutrient("Carbohydrates", "g", 240) },
        { "Fiber", new Nutrient("Fiber", "g", 35) },
        { "Sugars", new Nutrient("Sugars", "g", 30) },
        { "Starch", new Nutrient("Starch", "g", 0) },
        { "Fat", new Nutrient("Fat", "g", 70) },
        { "TransFat", new Nutrient("TransFat", "g", 2.2) },
        { "MonounsaturatedFat", new Nutrient("MonounsaturatedFat", "g", 40) },
        { "PolyunsaturatedFat", new Nutrient("PolyunsaturatedFat", "g", 15) },
        { "SaturatedFat", new Nutrient("SaturatedFat", "g", 19) },
        { "Cholesterol", new Nutrient("Cholesterol", "mg", 300) },
        { "VitaminA", new Nutrient("VitaminA", "IU", 2999997) },
        { "VitaminD", new Nutrient("VitaminD", "IU", 49999.95) },
        { "VitaminE", new Nutrient("VitaminE", "mg", 15) },
        { "VitaminC", new Nutrient("VitaminC", "mg", 90) },
        { "VitaminK1", new Nutrient("VitaminK1", "mcg", 120000) },
        { "VitaminK2", new Nutrient("VitaminK2", "mcg", 250000) },
        { "Thiamin", new Nutrient("Thiamin", "mg", 1.2) },
        { "Riboflavin", new Nutrient("Riboflavin", "mg", 1.6) },
        { "Niacin", new Nutrient("Niacin", "mg", 16) },
        { "PantothenicAcid", new Nutrient("PantothenicAcid", "mg", 5) },
        { "VitaminB6", new Nutrient("VitaminB6", "mg", 1.3) },
        { "Biotin", new Nutrient("Biotin", "mcg", 100) },
        { "Folate", new Nutrient("Folate", "mcg", 400) },
        { "VitaminB12", new Nutrient("VitaminB12", "mcg", 2.4) },
        { "Choline", new Nutrient("Choline", "mg", 550) },
        { "FolicAcid", new Nutrient("FolicAcid", "mcg", 400) },
        { "CaroteneAlpha", new Nutrient("CaroteneAlpha", "mcg", 900) },
        { "CaroteneBeta", new Nutrient("CaroteneBeta", "mcg", 15000) },
        { "CryptoxanthinBeta", new Nutrient("CryptoxanthinBeta", "mcg", 200000) },
        { "LuteinZeaxanthin", new Nutrient("LuteinZeaxanthin", "mcg", 10000) },
        { "Lycopene", new Nutrient("Lycopene", "mcg", 21000) },
        { "Calcium", new Nutrient("Calcium", "mg", 1000) },
        { "Chromium", new Nutrient("Chromium", "mcg", 35) },
        { "Iron", new Nutrient("Iron", "mg", 8) },
        { "Zinc", new Nutrient("Zinc", "mg", 11) },
        { "Sodium", new Nutrient("Sodium", "mg", 2.3) },
        { "Magnesium", new Nutrient("Magnesium", "mg", 400) },
        { "Copper", new Nutrient("Copper", "mg", 2) },
        { "Fluoride", new Nutrient("Fluoride", "mcg", 4000) },
        { "Iodine", new Nutrient("Iodine", "mcg", 150) },
        { "Manganese", new Nutrient("Manganese", "mg", 2.3) },
        { "Molybdenum", new Nutrient("Molybdenum", "mcg", 45) },
        { "Nickel", new Nutrient("Nickel", "mcg", 70) },
        { "Phosphorus", new Nutrient("Phosphorus", "mg", 700) },
        { "Potassium", new Nutrient("Potassium", "mg", 3400) },
        { "Phosphorous", new Nutrient("Phosphorous", "mg", 700) },
        { "Selenium", new Nutrient("Selenium", "mcg", 55) },
        { "Alanine", new Nutrient("Alanine", "g", 4) },
        { "Arginine", new Nutrient("Arginine", "g", 15) },
        { "Asparagine", new Nutrient("Asparagine", "g", 5) },
        { "AsparticAcid", new Nutrient("AsparticAcid", "g", 3) },
        { "Cystine", new Nutrient("Cystine", "g", 0.5) },
        { "GlutamicAcid", new Nutrient("GlutamicAcid", "g", 15) },
        { "Glutamine", new Nutrient("Glutamine", "g", 6) },
        { "Glycine", new Nutrient("Glycine", "g", 4) },
        { "Histidine", new Nutrient("Histidine", "g", 0.7) },
        { "Isoleucine", new Nutrient("Isoleucine", "g", 2.2) },
        { "Leucine", new Nutrient("Leucine", "g", 2.8) },
        { "Lysine", new Nutrient("Lysine", "g", 3) },
        { "Methionine", new Nutrient("Methionine", "g", 1) },
        { "Phenylalanine", new Nutrient("Phenylalanine", "g", 2) },
        { "Proline", new Nutrient("Proline", "g", 2) },
        { "Serine", new Nutrient("Serine", "g", 8) },
        { "Threonine", new Nutrient("Threonine", "g", 1) },
        { "Tryptophan", new Nutrient("Tryptophan", "g", 1) },
        { "Tyrosine", new Nutrient("Tyrosine", "g", 1) },
        { "Valine", new Nutrient("Valine", "g", 2) },
        { "Theobromine", new Nutrient("Theobromine", "g", 0.450) },
    };

    private Dictionary<MealOfDay, TimePeriod> MealPeriods { get; } = new()
    {
        { MealOfDay.Breakfast, new TimePeriod(TimeSpan.FromHours(6), TimeSpan.FromHours(10)) },
        { MealOfDay.Lunch, new TimePeriod(TimeSpan.FromHours(11), TimeSpan.FromHours(14)) },
        { MealOfDay.Dinner, new TimePeriod(TimeSpan.FromHours(17), TimeSpan.FromHours(20)) },
    };

    public SettingsService()
    {
        LoadAndSetTimePeriod(MealOfDay.Breakfast);
        LoadAndSetTimePeriod(MealOfDay.Lunch);
        LoadAndSetTimePeriod(MealOfDay.Dinner);
    }

    private void LoadAndSetTimePeriod(MealOfDay mealOfDay)
    {
        Preferences.Clear();
        var timePeriodJson = Preferences.Get(mealOfDay.ToString(), "");
        if (!string.IsNullOrEmpty(timePeriodJson))
        {
            var deserializedTimePeriod = JsonConvert.DeserializeObject<TimePeriod>(timePeriodJson);
            MealPeriods[mealOfDay] = deserializedTimePeriod;
        }
    }

    public Nutrient GetNutrientNeed(string key)
    {
        return NutrientNeeds.TryGetValue(key, out var valueExist) ? valueExist : null;
    }

    public IEnumerable<Nutrient> GetAllNutrientNeeds()
    {
        return NutrientNeeds.Values;
    }

    public TimePeriod GetMealPeriod(MealOfDay mealOfDay)
    {
        return MealPeriods.TryGetValue(mealOfDay, out var valueExist) ? valueExist : null;
    }
}