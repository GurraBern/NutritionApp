using Nutrition.Core;

namespace NutritionApp.Data.Services;

public interface IMeasurementsService

{
    public Task<IEnumerable<BodyMeasurement>> GetBodyMeasurements();

    public TargetMeasurement GetTargetMeasurements();

    public Task AddNewWeight(double weight);
}