using NutritionTrackR.Core.BodyMeasurements.Events;
using NutritionTrackR.Core.Shared;
using NutritionTrackR.Core.Shared.ValueObjects;

namespace NutritionTrackR.Core.BodyMeasurements;

public class BodyWeight : AggregateRoot
{
    public DateTime Date { get; set; }
    public Weight Weight { get; private set; }
    
    public BodyWeight(){}
    
    public void Process(IEnumerable<WeightEvent> weightEvents)
    {
        foreach (var weightEvent in weightEvents)
        {
            Apply(weightEvent);
        }
    }
    
    private void Apply(WeightEvent @event)
    {
        //TODO add remove WeightEntryEvent?
        //TODO insert weight entry at specific date
        switch (@event)
        {
            case WeightTracked weightTracked:
                Apply(weightTracked);
                break;
        }
    }

    private void Apply(WeightTracked @event)
    {
        Date = @event.OccuredAt;
        Weight = @event.Weight;
    }
}