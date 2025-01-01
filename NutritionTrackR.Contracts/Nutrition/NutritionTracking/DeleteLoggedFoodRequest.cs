namespace NutritionTrackR.Contracts.Nutrition.NutritionTracking;

public record DeleteLoggedFoodRequest
{
    public DateTime Date { get; set; }
    public Guid LoggedFoodId { get; set; }
}