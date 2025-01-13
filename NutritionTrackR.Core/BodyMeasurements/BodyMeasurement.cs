using NutritionTrackR.Core.BodyMeasurements.ValueObjects;
using NutritionTrackR.Core.Shared;
using NutritionTrackR.Core.Shared.ValueObjects;

namespace NutritionTrackR.Core.BodyMeasurements;

public class BodyMeasurement : Entity
{
    public DateTime Date { get; init; } = DateTime.Now;
    public Weight Weight { get; init; }
    public List<Measurement> Measurements { get; private set; } = [];
    
    private BodyMeasurement(){}

    public BodyMeasurement(Weight weight)
    {
        Weight = weight;
    }

    public BodyMeasurement(DateTime date, Weight weight, IEnumerable<Measurement> measurements)
    {
        Date = date;
        Weight = weight;
        Measurements = measurements.ToList();
    }
}