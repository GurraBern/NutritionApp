using Nutrition.Core;
using NutritionApp.MVVM.Models;

namespace NutritionApp.Services.NutritionServices;

public interface ISettingsService
{
    Nutrient GetNutrientNeed(string key);

    IEnumerable<Nutrient> GetAllNutrientNeeds();

    TimePeriod GetMealPeriod(MealOfDay mealOfDay);

    MealOfDay GetCurrentMealPeriod();
}