using MongoDB.Bson;

namespace NutritionTrackR.Core.Shared;

public abstract class Entity
{
    public ObjectId Id { get; set; }

    // public List<BaseDomainEvent> Events { get; set; } = [];
}