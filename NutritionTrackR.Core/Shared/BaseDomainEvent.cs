using MediatR;

namespace NutritionTrackR.Core.Shared;

public abstract class BaseDomainEvent : INotification
{
    public DateTimeOffset OccurredAt { get; protected set; } = DateTimeOffset.UtcNow;
}