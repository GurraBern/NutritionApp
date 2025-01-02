namespace NutritionTrackR.Web.Extensions;

public static class DateExtensions
{
    public static DateTime ToDateTime(this DateOnly date)
    {
        return date.ToDateTime(TimeOnly.MinValue);
    }
}