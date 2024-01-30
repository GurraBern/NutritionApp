using Nutrition.Core;

namespace NutritionApp.Data.Context.Interfaces;

public interface IUserContext
{
    ICollection<BodyMeasurement> BodyMeasurements { get; }
    TargetMeasurement TargetMeasurement { get; }
    BodyMeasurement CurrentBodyMeasurement { get; set; }
    double BMI { get; set; }
    double WeightProgress { get; set; }
    Task AddBodyMeasurement(BodyMeasurement bodyMeasurement);
}
