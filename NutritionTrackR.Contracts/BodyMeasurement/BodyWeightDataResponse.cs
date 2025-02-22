using System.Text.Json.Serialization;

namespace NutritionTrackR.Contracts.BodyMeasurement;

public record BodyWeightDataResponse
{
	[JsonPropertyName("bodyWeightData")]
	public IEnumerable<WeightDto> BodyWeightData { get; set; } = [];
}

public record WeightDto(double Amount, string Unit, DateTime Date)
{
	[JsonPropertyName("amount")]
	public double Amount { get; set; } = Amount;
	
	[JsonPropertyName("unit")]
	public string Unit { get; set; } = Unit;

	[JsonPropertyName("date")]
	public DateTime Date { get; set; } = Date;
	
	public string ToDisplayString() => $"{Amount} {Unit}";
}
