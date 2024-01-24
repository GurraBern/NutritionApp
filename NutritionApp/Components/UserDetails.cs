using Nutrition.Core;
using NutritionApp.Data.Services;

namespace NutritionApp.Components;

public class UserDetails
{
    private readonly IMeasurementsService _measurementsService;
    public IEnumerable<BodyMeasurement> BodyMeasurements { get; }
    public TargetMeasurements TargetMeasurements { get; }
    public double BMI { get; }
    public double Weight { get; }
    public double WeightProgress { get; }

    public UserDetails(IMeasurementsService measurementsService)
    {
        _measurementsService = measurementsService;
        BodyMeasurements = await measurementsService.GetBodyMeasurements();
        TargetMeasurements = measurementsService.GetTargetMeasurements();

        var bodyMeasurement = BodyMeasurements.FirstOrDefault();
        Weight = bodyMeasurement.Weight;

        BMI = CalculateBMI(bodyMeasurement.Weight, bodyMeasurement.Height);
        WeightProgress = CalculateWeightProgess();
    }

    private static double CalculateBMI(double weight, double height)
    {
        var bmi = weight / Math.Pow(height, 2);
        return Math.Round(bmi, 2);
    }

    private double CalculateWeightProgess()
    {
        var targetWeight = TargetMeasurements.TargetWeight;
        var currentWeight = BodyMeasurements.FirstOrDefault().Weight;
        var startingWeight = TargetMeasurements.StartingWeight;
        return (currentWeight - startingWeight) / (targetWeight - startingWeight);
    }
}

public class TargetMeasurements
{
    public double TargetWeight { get; set; }
    public double StartingWeight { get; set; }
    public DateTime TargetCreationDate { get; set; }
    public DateTime TargetEndDate { get; set; }
}