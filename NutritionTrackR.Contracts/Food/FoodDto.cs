using System.Text.Json.Serialization;

namespace NutritionTrackR.Contracts.Food;

public class FoodDto
{
	[JsonPropertyName("name")]
	public string Name { get; set; }
    
	[JsonPropertyName("nutrients")]
	public List<NutrientDto> Nutrients { get; set; }
}