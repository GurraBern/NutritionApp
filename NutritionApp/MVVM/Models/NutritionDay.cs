using CommunityToolkit.Mvvm.ComponentModel;
using NutritionApp.Services.NutritionServices;

namespace NutritionApp.MVVM.Models;

public class NutritionDay : ObservableObject
{
    public DateTime Date { get; set; }
    public List<FoodItem> ConsumedFoodItems { get; set; } = new();
    public Dictionary<string, double> NutrientTotals { get; set; } = new()
    {
        { "Calories", 0 },
        { "Protein", 0 },
        { "Carbohydrates", 0 },
        { "Fat", 0 },
        { "SaturatedFat", 0 },
        { "Cholesterol", 0 },
        { "VitaminA", 0 },
        { "VitaminD", 0 },
        { "VitaminE", 0 },
        { "VitaminC", 0 },
        { "VitaminK", 0 },
        { "Thiamin", 0 },
        { "Riboflavin", 0 },
        { "Niacin", 0 },
        { "PantothenicAcid", 0 },
        { "VitaminB6", 0 },
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
        { "Iron", 0 },
        { "Zink", 0 },
        { "Sodium", 0 },
        { "Magnesium", 0 },
        { "Copper", 0 },
        { "Manganese", 0 },
        { "Phosphorous", 0 },
        { "Selenium", 0 },
        { "Alanine", 0 },
        { "Arginine", 0 },
        { "AsparticAcid", 0 },
        { "Cystine", 0 },
        { "GlutamicAcid", 0 },
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
        { "Valine", 0 }
    };

    public NutritionDay(DateTime date)
    {
        Date = date;
    }

    public void AddFood(FoodItem food)
    {
        ConsumedFoodItems.Add(food);
        NutrientCalculator.SumNutrients(food, NutrientTotals);
    }

    public List<FoodItem> GetConsumedFoods()
    {
        return ConsumedFoodItems;
    }
}
