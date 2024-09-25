namespace NutritionTrackR.Core.NutrientTracking;

public interface INutritionDayRepository
{
	Task<NutritionDay?> GetById(string id);
	Task<int> SaveAsync();
	Task Create(NutritionDay nutritionDay);
}