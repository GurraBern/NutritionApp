using NutritionApp.Components;
using NutritionApp.MVVM.Models;
using NutritionApp.Services;

namespace NutritionApp.MVVM.ViewModels;

public class ProgressViewModel(UserDetails userDetails, NavigationService navigationService)
{
    public NavigationService NavigationService { get; } = navigationService;
    public BodyMeasurements BodyMeasurements { get; set; } = userDetails.BodyMeasurements;
    public TargetMeasurements TargetMeasurements { get; set; } = userDetails.TargetMeasurements;
    public double BMI { get; set; } = userDetails.BMI;
    public double WeightProgress { get; set; } = userDetails.WeightProgress;
}