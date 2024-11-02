using MediatR;

namespace NutritionTrackR.Core.Shared;

public class DomainEvent : INotification
{
    public DateTimeOffset OccurredAt { get; set; }
}