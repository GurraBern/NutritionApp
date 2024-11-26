namespace NutritionTrackR.Core.Nutrition.Target;

public interface INutritionTargetRepository
{
    Task<NutritionTarget?> GetNutritionTarget(DateTime date);
    Task Add(NutritionTarget nutritionTarget);
}