using Nutrition.Core;

namespace NutritionApp.Data.Context.Interfaces;

public interface IUserContext
{
    IEnumerable<BodyMeasurement> BodyMeasurements { get; }
    TargetMeasurement TargetMeasurement { get; }
    BodyMeasurement CurrentBodyMeasurement { get; set; }
    double BMI { get; set; }
    double WeightProgress { get; set; }
}
