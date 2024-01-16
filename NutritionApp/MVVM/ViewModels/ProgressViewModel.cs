using NutritionApp.Services;

namespace NutritionApp.MVVM.ViewModels;

public class ProgressViewModel(IUserDetailService userDetailService)
{
    public double BMI { get; set; } = CalculateBMI(74.5f, 1.68f);
    public double Height { get; set; } = userDetailService.GetHeight();
    public double Weight { get; set; } = userDetailService.GetWeight();

    public static double CalculateBMI(float weight, float height)
    {
        var bmi = weight / Math.Pow(height, 2);
        return Math.Round(bmi, 2);
    }
}