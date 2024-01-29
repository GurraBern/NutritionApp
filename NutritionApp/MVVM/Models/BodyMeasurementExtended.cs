using Nutrition.Core;

namespace NutritionApp.MVVM.Models;

public class BodyMeasurementExtended
{
    private BodyMeasurement _bodyMeasurement;
    public double Difference { get; set; } = 0;
    public double Weight { get => _bodyMeasurement.Weight; }
    public double Height { get => _bodyMeasurement.Height; }
    public DateTime DateTime { get => _bodyMeasurement.DateTime; }

    public BodyMeasurementExtended(BodyMeasurement bodyMeasurement)
    {
        _bodyMeasurement = bodyMeasurement;
    }
}
