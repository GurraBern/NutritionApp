using Nutrition.Core;

namespace NutritionApp.Data.Services;

public interface IMeasurementsService

{
    public Task<IEnumerable<BodyMeasurement>> GetBodyMeasurements();

    public Task<BodyMeasurement> GetLatestBodyMeasurement();

    public TargetMeasurement GetTargetMeasurements();

    public Task AddNewWeight(double weight);
}