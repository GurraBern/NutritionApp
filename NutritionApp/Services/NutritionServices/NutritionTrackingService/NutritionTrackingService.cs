using CommunityToolkit.Mvvm.ComponentModel;
using NutritionApp.MVVM.Models;

namespace NutritionApp.Services.NutritionServices.NutritionTrackingService;

public class NutritionTrackingService : ObservableObject, INutritionTracker
{
    public List<FoodItem> ConsumedFoods { get; set; } = new List<FoodItem>();
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
    public Dictionary<string, double> NutrientNeeds { get; set; } = new()
    {
        { "Calories", 2400 },
        { "Protein", 110 },
        { "Carbohydrates", 240 },
        { "Fat", 70 },
        { "SaturatedFat", 19 },
        { "Cholesterol", 0.3 },
        { "VitaminA", 0.0009 },
        { "VitaminD", 0.000015 },
        { "VitaminE", 0.015 },
        { "VitaminC", 0.075 },
        { "VitaminK", 0.00012 },
        { "Thiamin", 0.0012 },
        { "Riboflavin", 0.0013 },
        { "Niacin", 0.016 },
        { "PantothenicAcid", 0.005 },
        { "VitaminB6", 0.0013 },
        { "Folate", 0.0004 },
        { "VitaminB12", 0.0000024 },
        { "TocopherolAlpha", 0.015 },
        { "Choline", 0.550 },
        { "FolicAcid", 0.0004 },
        { "CaroteneAlpha", 0.0009 },
        { "CaroteneBeta", 0.180 },
        { "CryptoxanthinBeta", 1 }, // RecommendedDosageUnknown
        { "LuteinZeaxanthin", 0.020 },
        { "Lycopene", 0.021 },
        { "Calcium", 1 },
        { "Iron", 0.008 },
        { "Zink", 0.011 },
        { "Sodium", 1.5 },
        { "Magnesium", 0.4 },
        { "Copper", 0.0009 },
        { "Manganese", 0.0023 },
        { "Phosphorous", 0.7 },
        { "Selenium", 0.000055 },
        { "Alanine", 3.2 },
        { "Arginine", 15 },
        { "AsparticAcid", 3 },
        { "Cystine", 0.287 },
        { "GlutamicAcid", 15 },
        { "Histidine", 0.7 },
        { "Hydroxyproline", 1 }, // RecommendedDosageUnknown
        { "Isoleucine", 6 },
        { "Leucine", 10 },
        { "Lysine", 3 },
        { "Methionine", 0.91 },
        { "Phenylalanine", 2 },
        { "Proline", 5 },
        { "Serine", 8 },
        { "Threonine", 1 },
        { "Tryptophan", 0.35 },
        { "Tyrosine", 10 },
        { "Valine", 2 }
    };

    public NutritionTrackingService()
    {

    }

    public void AddFood(FoodItem food)
    {
        ConsumedFoods.Add(food);

        NutrientCalculator.SumNutrients(food, NutrientTotals);
    }

    public void RemoveFood(FoodItem food)
    {
        ConsumedFoods.Remove(food);
    }
}
