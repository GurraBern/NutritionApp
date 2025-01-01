using System.Text.Json.Serialization;

namespace NutritionTrackR.Contracts.Nutrition.NutritionTracking;

public record LoggedFoodResponse
{
	[JsonPropertyName("foods")]
	public List<LoggedFoodDto> Foods { get; set; } = [];
}