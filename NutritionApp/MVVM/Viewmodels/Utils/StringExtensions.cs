namespace NutritionApp.MVVM.ViewModels;

public static class StringExtensions
{
    public static bool IsEqualOrEmpty(this string input, string compareString)
    {
        return string.Equals(input, compareString) || string.IsNullOrEmpty(input);
    }
}
