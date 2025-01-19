namespace NutritionTrackR.Core.Shared.Abstractions;

public abstract class Event : Entity
{
    public abstract Guid StreamId { get; set; }

    public DateTime OccuredAt { get; set; } = DateTime.Now;
}