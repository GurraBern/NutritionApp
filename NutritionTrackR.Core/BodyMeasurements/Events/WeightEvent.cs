using NutritionTrackR.Core.Shared.Abstractions;
using NutritionTrackR.Core.Shared.ValueObjects;

namespace NutritionTrackR.Core.BodyMeasurements.Events;

public abstract class WeightEvent : Event
{
    public abstract string Descriptor { get; set; }
    
    public Guid UserId { get; protected set; }

    override public Guid StreamId
    {
        get => UserId;
        set => UserId = value;
    }

    public Weight Weight { get; protected set; }
}