using System.Text.Json.Serialization;

namespace NutritionTrackR.Contracts.Food;

public class CreateFoodRequest
{
	public string Name { get; set; }
	public List<NutrientDto> Nutrients { get; set; } = [];
}

public class NutrientDto
{
	[JsonPropertyName("name")]
	public string Name { get; set; }
    
	[JsonPropertyName("weight")]
	public double Weight { get; set; }
    
	[JsonPropertyName("unit")]
	public UnitDto Unit { get; set; }
}

public enum UnitDto
{
	Serving = 0,
	Grams = 1,
	Milligram = 2,
	Microgram = 3,
	Pound = 4,
	Ounce = 5
}

public enum MealTypeDto
{
	Unclassified = 0,
	Breakfast = 1,
	Lunch = 2,
	Dinner = 3,
	Snack = 4
}