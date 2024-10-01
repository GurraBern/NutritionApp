using MediatR;

namespace NutritionTrackR.Core.Shared;

public interface IDomainEvent : INotification
{
    public DateTimeOffset OccurredAt { get; protected set; }
}