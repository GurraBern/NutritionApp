using System.Text.Json.Serialization;

namespace NutritionTrackR.Contracts.BodyMeasurement;

public record BodyWeightDataResponse
{
	[JsonPropertyName("bodyWeightData")]
	public IEnumerable<WeightDto> BodyWeightData { get; set; } = [];
}

public record WeightDto(string Id, double Amount, string Unit, DateTime Date)
{
	[JsonPropertyName("id")]
	public string Id { get; set; } = Id;
	
	[JsonPropertyName("amount")]
	public double Amount { get; set; } = Amount;
	
	[JsonPropertyName("unit")]
	public string Unit { get; set; } = Unit;

	[JsonPropertyName("date")]
	public DateTime Date { get; set; } = Date;
	
	public string ToDisplayString() => $"{Amount} {Unit}";
}
