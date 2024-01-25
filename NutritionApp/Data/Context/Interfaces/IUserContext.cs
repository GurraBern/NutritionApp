using Nutrition.Core;

namespace NutritionApp.Data.Context.Interfaces;

public interface IUserContext
{
    IEnumerable<BodyMeasurement> BodyMeasurements { get; }
}
