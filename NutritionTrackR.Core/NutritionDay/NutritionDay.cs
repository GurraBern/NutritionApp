using NutritionTrackR.Core.Food;

namespace NutritionTrackR.Core.NutritionDay;

public class NutritionDay
{
    public IList<FoodEntry> FoodEntries { get; } = [];
}