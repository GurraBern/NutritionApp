using System.Text.Json.Serialization;
using NutritionTrackR.Core.Foods.ValueObjects;

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
	public Unit Unit { get; set; }
    
	[JsonPropertyName("nutrients")]
	public List<NutrientDto> Nutrients { get; set; }
}