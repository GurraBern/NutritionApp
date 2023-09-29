using CommunityToolkit.Mvvm.ComponentModel;
using NutritionApp.MVVM.Models;

namespace NutritionApp.Services.NutritionServices;

public class NutritionTrackingService : ObservableObject, INutritionTracker
{
    private int dayIndex = 0;
    public NutritionDay NutritionDay { get; set; }
    public List<NutritionDay> NutritionDays = new();
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
        //TODO Load NutritionDay if exists from db otherwise create
        NutritionDay = new NutritionDay(DateTime.Today);
        NutritionDays.Add(NutritionDay);
    }

    public void AddFood(FoodItem food)
    {
        NutritionDay.AddFood(food);
    }

    public void RemoveFood(FoodItem food)
    {
        //nutritionDay.Remove(food);
    }

    public NutritionDay NextDay()
    {
        dayIndex--;
        if (dayIndex < 0)
            dayIndex = 0;

        NutritionDay = NutritionDays[dayIndex];
        return NutritionDay;
    }

    public NutritionDay PreviousDay()
    {
        dayIndex++;
        if (dayIndex >= NutritionDays.Count)
        {
            NutritionDays.Add(new NutritionDay(DateTime.Today.AddDays(-dayIndex)));
        }

        NutritionDay = NutritionDays[dayIndex];
        return NutritionDay;
    }
}
