using NutritionTrackR.Core.Shared.ValueObjects;

namespace NutritionTrackR.Core.BodyMeasurements.Events;

public class WeightTracked : WeightEvent
{
    override public string Descriptor { get; set; } = nameof(WeightTracked);

    private WeightTracked() {}
    
    public WeightTracked(Guid userId, Weight weight)
    {
        UserId = userId;
        Weight = weight;
    }
}