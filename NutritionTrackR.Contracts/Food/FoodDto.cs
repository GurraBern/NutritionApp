using System.Text.Json.Serialization;

namespace NutritionTrackR.Contracts.Food;

public class FoodDto
{
	
	[JsonPropertyName("id")]
	public string Id { get; set; }
	
	[JsonPropertyName("name")]
	public string Name { get; set; }
	
	[JsonPropertyName("amount")]
	public double Amount { get; set; }
	
	[JsonPropertyName("unit")]
	public UnitDto Unit { get; set; }
    
	[JsonPropertyName("nutrients")]
	public List<NutrientDto> Nutrients { get; set; }
	public MealTypeDto MealType { get; set; }
}