namespace NutritionTrackR.Contracts.Food;

public class FoodDto
{
	public string Name { get; set; }

	public static FoodDto ToDto(Core.Food.Food food)
	{
		return new FoodDto()
		{
			Name = food.Name
		};
	}
}