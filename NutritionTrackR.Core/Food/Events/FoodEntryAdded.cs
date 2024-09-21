using NutritionTrackR.Core.Shared;

namespace NutritionTrackR.Core.Food.Events;

public class FoodEntryAdded : BaseDomainEvent
{
    public Food Food { get; set; }
}