using System.Text.Json.Serialization;
using NutritionTrackR.Contracts.Food;

namespace NutritionTrackR.Contracts.Nutrition.Target;

public class NutritionTargetDto
{
    [JsonPropertyName("date")]
    public DateOnly Date { get; set; } = DateOnly.FromDateTime(DateTime.Now);
    
    [JsonPropertyName("nutrients")]
    public List<NutrientDto> Nutrients { get; set; }
}