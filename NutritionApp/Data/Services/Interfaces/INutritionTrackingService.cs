using Nutrition.Core;

namespace NutritionApp.Data.Services;

public interface INutritionTrackingService
{
    Task<NutritionDayV1> GetNutritionDay(DateTime dateToQuery);

    Task SaveNutritionDay(NutritionDayV1 nutritionDayV1);
}