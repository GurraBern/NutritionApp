using System.Text.Json.Serialization;

namespace NutritionTrackR.Contracts.BodyMeasurement;

public record BodyWeightDataResponse
{
	[JsonPropertyName("bodyWeightData")]
	public IEnumerable<WeightDto> BodyWeightData { get; set; } = [];
}

public record WeightDto(double Amount, string Unit)
{
	[JsonPropertyName("amount")]
	public double Amount { get; set; } = Amount;
	
	[JsonPropertyName("unit")]
	public string Unit { get; set; } = Unit;
}
