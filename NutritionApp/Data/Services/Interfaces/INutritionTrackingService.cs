using Nutrition.Core;

namespace NutritionApp.Data.Services;

public interface INutritionTrackingService
{
    Task<NutritionDay> GetNutritionDay(DateTime dateToQuery);

    Task SaveNutritionDay(NutritionDay nutritionDay);
}