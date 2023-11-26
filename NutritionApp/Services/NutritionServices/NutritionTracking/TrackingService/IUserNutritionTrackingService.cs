using Nutrition.Core;

namespace NutritionApp.Services.NutritionServices;

public interface INutritionTrackingService
{
    Task<NutritionDay> GetNutritionDay(DateTime dateToQuery);

    Task SaveNutritionDay(NutritionDay nutritionDay);
}