using Nutrition.Core;
using NutritionApp.Data.Context.Interfaces;
using NutritionApp.Data.Services;
using NutritionApp.MVVM;

namespace NutritionApp.Data.Context;

public class UserContext : IUserContext, IAsyncInitialization
{
    private readonly IMeasurementsService _measurementsService;
    public ICollection<BodyMeasurement> BodyMeasurements { get; set; }
    public BodyMeasurement CurrentBodyMeasurement { get; set; }
    public TargetMeasurement TargetMeasurement { get; set; }
    public double BMI { get; set; }
    public double Weight { get; set; }
    public double WeightProgress { get; set; }

    public Task Initialization { get; private set; }

    public UserContext(IMeasurementsService measurementsService)
    {
        _measurementsService = measurementsService;

        Initialization = InitializeAsync();
    }

    public async Task AddBodyMeasurement(BodyMeasurement bodyMeasurement)
    {
        BodyMeasurements.Add(bodyMeasurement);
        await _measurementsService.AddNewWeight(bodyMeasurement.Weight);
    }

    private async Task InitializeAsync()
    {
        BodyMeasurements = (await _measurementsService.GetBodyMeasurements()).ToList();
        CurrentBodyMeasurement = await _measurementsService.GetLatestBodyMeasurement();
        Weight = CurrentBodyMeasurement.Weight;
        BMI = CalculateBMI(CurrentBodyMeasurement.Weight, CurrentBodyMeasurement.Height);
        TargetMeasurement = _measurementsService.GetTargetMeasurements();

        WeightProgress = CalculateWeightProgess();
    }

    private static double CalculateBMI(double weight, double height)
    {
        var bmi = weight / Math.Pow(height, 2);
        return Math.Round(bmi, 2);
    }

    private double CalculateWeightProgess()
    {
        var targetWeight = TargetMeasurement.TargetWeight;
        var currentWeight = CurrentBodyMeasurement.Weight;
        var startingWeight = TargetMeasurement.StartingWeight;
        return (currentWeight - startingWeight) / (targetWeight - startingWeight);
    }
}
