using Nutrition.Core;

namespace NutritionApp.Services.NutritionServices;

public interface ISettingsService
{
    Nutrient GetNutrientNeed(string key);
    IEnumerable<Nutrient> GetAllNutrientNeeds();
}