using NutritionTrackR.Contracts.Food;

namespace NutritionTrackR.Contracts.Nutrition.NutritionTracking;

public record UpdateLoggedFoodRequest
{
    public DateTime Date { get; set; } 
    public Guid LoggedFoodId { get; set; }
    public string FoodId { get; set; }
	public decimal Weight { get; set; }
	public string Unit { get; set; }
	public MealTypeDto MealType { get; set; }
}