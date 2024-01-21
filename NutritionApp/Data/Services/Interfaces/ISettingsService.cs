using Nutrition.Core;
using NutritionApp.MVVM.Models;

namespace NutritionApp.Data.Services;

public interface ISettingsService
{
    Nutrient GetNutrientNeed(string key);

    IEnumerable<Nutrient> GetAllNutrientNeeds();

    TimePeriod GetMealPeriod(MealOfDay mealOfDay);

    MealOfDay GetCurrentMealPeriod();
}