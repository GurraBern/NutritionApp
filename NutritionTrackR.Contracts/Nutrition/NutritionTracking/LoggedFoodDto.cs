using System.Text.Json.Serialization;
using NutritionTrackR.Contracts.Food;

namespace NutritionTrackR.Contracts.Nutrition.NutritionTracking;

public record LoggedFoodDto : FoodDto
{
	
	[JsonPropertyName("loggedFoodId")]
	public Guid LoggedFoodId { get; set; }
    
	public LoggedFoodDto() { }

	public LoggedFoodDto(string name, List<NutrientDto> nutrients, double amount, string unit, MealTypeDto mealType) :
		base(name, nutrients, amount, unit, mealType)
	{
	}
}