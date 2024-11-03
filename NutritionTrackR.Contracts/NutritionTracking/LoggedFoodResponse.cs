using System.Text.Json.Serialization;
using NutritionTrackR.Contracts.Food;

namespace NutritionTrackR.Contracts.NutritionTracking;

public class LoggedFoodResponse
{
	
	[JsonPropertyName("foods")]
	public List<DetailedFoodDto> Foods { get; set; }
}