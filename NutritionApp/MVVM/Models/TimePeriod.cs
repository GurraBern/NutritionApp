namespace NutritionApp.MVVM.Models;

public class TimePeriod(TimeSpan startTime, TimeSpan endTime)
{
    public TimeSpan StartTime { get; set; } = startTime;
    public TimeSpan EndTime { get; set; } = endTime;
}