using CommunityToolkit.Mvvm.ComponentModel;
using Google.Cloud.Firestore;
using NutritionApp.Services.NutritionServices;

namespace NutritionApp.MVVM.Models;

[FirestoreData]
public class NutritionDay : ObservableObject
{
    [FirestoreProperty]
    public string Date { get; set; } = DateTime.UtcNow.ToString("yyyy-MM-dd");

    [FirestoreProperty]
    public List<FoodItem> ConsumedFoodItems { get; set; } = new();

    [FirestoreProperty]
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
        { "VitaminK1", 0 },
        { "VitaminK2", 0 },
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
        ConsumedFoodItems.Add(food);
        NutrientCalculator.SumNutrients(food, NutrientTotals);
    }
}
