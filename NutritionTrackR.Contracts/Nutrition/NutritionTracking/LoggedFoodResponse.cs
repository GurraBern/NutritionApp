using System.Text.Json.Serialization;

namespace NutritionTrackR.Contracts.Nutrition.NutritionTracking;

public class LoggedFoodResponse
{
	[JsonPropertyName("foods")]
	public List<LoggedFoodDto> Foods { get; set; } = [];
}