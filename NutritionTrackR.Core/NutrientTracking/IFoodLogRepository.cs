using NutritionTrackR.Core.NutrientTracking.Events;

namespace NutritionTrackR.Core.NutrientTracking;

public interface IFoodEntryRepository
{
	IEnumerable<FoodLoggedEvent> GetFoodEntries();
}
