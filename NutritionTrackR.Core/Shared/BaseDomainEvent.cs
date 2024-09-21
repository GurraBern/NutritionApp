using MediatR;

namespace NutritionTrackR.Core.Shared;

public abstract class BaseDomainEvent : INotification
{
    public DateTimeOffset DateOccurred { get; protected set; } = DateTimeOffset.UtcNow;
}