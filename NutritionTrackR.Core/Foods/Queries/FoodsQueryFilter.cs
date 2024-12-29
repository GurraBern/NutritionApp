using MongoDB.Bson;

namespace NutritionTrackR.Core.Foods.Queries;

public class FoodsQueryFilter
{
	public DateTime Date { get; set; }
	public string Name { get; set; } = string.Empty;
	public int HealthyScore { get; set; }
	public List<ObjectId> FoodIds { get; set; } = [];
}