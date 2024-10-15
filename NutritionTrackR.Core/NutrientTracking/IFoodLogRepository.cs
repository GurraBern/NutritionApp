namespace NutritionTrackR.Core.NutrientTracking;

public interface IFoodLogRepository
{
	Task<IEnumerable<NutritionDay>> GetNutritionDays();
	Task<NutritionDay?> GetByDate(DateTime date);
}
