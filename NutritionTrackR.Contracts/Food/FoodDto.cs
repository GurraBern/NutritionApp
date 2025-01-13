using System.Text.Json.Serialization;

namespace NutritionTrackR.Contracts.Food;

public record FoodDto
{
	
	[JsonPropertyName("id")]
	public string Id { get; set; }
	
	[JsonPropertyName("name")]
	public string Name { get; set; }
	
	[JsonPropertyName("amount")]
	public double Amount { get; set; }
	
	[JsonPropertyName("unit")]
	public string Unit { get; set; }
    
	[JsonPropertyName("nutrients")]
	public List<NutrientDto> Nutrients { get; set; }
	public MealTypeDto MealType { get; set; }
	
	public FoodDto() { }

	protected FoodDto(string name, List<NutrientDto> nutrients, double amount, string unit, MealTypeDto mealType)
	{
		Name = name;
		Amount = amount;
		Unit = unit;
		Nutrients = nutrients;
		MealType = mealType;
	}
}