namespace NutritionTrackR.Core.Nutrition.Tracking;

public interface INutritionDayRepository
{
	Task<NutritionDay?> GetById(string id);
	Task<int> SaveAsync();
	Task Create(NutritionDay nutritionDay);
	Task<NutritionDay?> GetByDate(DateTime date);
}