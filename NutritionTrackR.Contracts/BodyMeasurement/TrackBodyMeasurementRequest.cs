using System.Diagnostics.Metrics;
using System.Text.Json.Serialization;
using NutritionTrackR.Contracts.Food;

namespace NutritionTrackR.Contracts.BodyMeasurement;

public class TrackBodyMeasurementRequest
{
    [JsonPropertyName("date")]
    public DateTime Date { get; set; }
    
    [JsonPropertyName("weight")]
    public double Weight { get; set; }
    
    [JsonPropertyName("unit")]
    public string WeightUnit { get; set; }

    [JsonPropertyName("measurements")]
    public List<MeasurementDto> Measurements { get; set; } = [];
}

public record MeasurementDto(decimal Length, string Unit);
