using System.Text.Json.Serialization;

namespace NutritionTrackR.Contracts.Food;

public record FoodResponse
{
	[JsonPropertyName("foods")]
	public List<FoodDto> Foods { get; set; }
}
