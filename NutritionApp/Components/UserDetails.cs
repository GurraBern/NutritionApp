using NutritionApp.MVVM.Models;
using NutritionApp.Services;

namespace NutritionApp.Components;

public class UserDetails
{
    private readonly IUserDetailService _userDetailService;
    public BodyMeasurements BodyMeasurements { get; }
    public TargetMeasurements TargetMeasurements { get; }
    public double BMI { get; }
    public double WeightProgress { get; }

    public UserDetails(IUserDetailService userDetailService)
    {
        _userDetailService = userDetailService;
        BodyMeasurements = userDetailService.GetBodyMeasurements();
        TargetMeasurements = userDetailService.GetTargetMeasurements();
        BMI = CalculateBMI(BodyMeasurements.Weight, BodyMeasurements.Height);
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
        var currentWeight = BodyMeasurements.Weight;
        var startingWeight = TargetMeasurements.StartingWeight;
        return (currentWeight - startingWeight) / (targetWeight - startingWeight);
    }
}

public class TargetMeasurements
{
    public double TargetWeight { get; set; }
    public double StartingWeight { get; set; }
    public DateTime TargetCreated { get; set; }
}