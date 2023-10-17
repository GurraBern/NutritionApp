using Nutrition.Core;

namespace NutritionApp.Services.NutritionServices;

public interface INutritionRepository
{
    Task<NutritionDay> GetNutritionDay(DateTime dateToQuery);
    Task InsertNutritionDay(NutritionDay nutritionDay);
    Task UpdateNutritionDay(NutritionDay nutritionDay);
}
