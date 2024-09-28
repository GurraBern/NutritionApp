namespace NutritionTrackR.Contracts.Food;

public class FoodResponse
{
	public List<FoodDto> Foods { get; set; } = [];

	public FoodResponse(List<FoodDto> foodDtos)
	{
		Foods = foodDtos;
	}

	public static FoodResponse MapResponse(IEnumerable<Core.Food.Food> foods)
	{
		var foodDtos = foods.Select(food =>
			new FoodDto()
			{
				Name = food.Name
			}).ToList();

		return new FoodResponse(foodDtos);
	}
}