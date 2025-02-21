using System.Diagnostics.Metrics;
using System.Text.Json.Serialization;
using NutritionTrackR.Contracts.Food;

namespace NutritionTrackR.Contracts.BodyMeasurement;

public class TrackBodyWeightRequest
{
    [JsonPropertyName("userId")]
    public Guid UserId { get; set; }
    
    [JsonPropertyName("date")]
    public DateTime Date { get; set; } = DateTime.UtcNow;
    
    [JsonPropertyName("weight")]
    public double Weight { get; set; }
    
    [JsonPropertyName("unit")]
    public string WeightUnit { get; set; }
}
