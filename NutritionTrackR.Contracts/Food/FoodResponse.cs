using System.Text.Json.Serialization;

namespace NutritionTrackR.Contracts.Food;

public class FoodResponse
{
	[JsonPropertyName("foods")]
	public List<FoodDto> Foods { get; set; }
}
