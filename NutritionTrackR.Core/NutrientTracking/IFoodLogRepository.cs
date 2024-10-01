using NutritionTrackR.Core.NutrientTracking.Events;

namespace NutritionTrackR.Core.NutrientTracking;

public interface IFoodLogRepository
{
	Task<IEnumerable<NutritionDay>> GetNutritionDays();
}
