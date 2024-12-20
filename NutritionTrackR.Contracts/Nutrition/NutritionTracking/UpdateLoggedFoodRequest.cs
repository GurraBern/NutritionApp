using NutritionTrackR.Contracts.Food;

namespace NutritionTrackR.Contracts.Nutrition.NutritionTracking;

public class UpdateLoggedFoodRequest
{
    public DateTime Date { get; set; } 
    public Guid LoggedFoodId { get; set; }
    public string FoodId { get; set; }
	public decimal Weight { get; set; }
	public UnitDto Unit { get; set; }
	public MealTypeDto MealType { get; set; }
}