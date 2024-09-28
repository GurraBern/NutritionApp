using NutritionTrackR.Contracts.Food;
using NutritionTrackR.Core.Food;
using NutritionTrackR.Core.Food.ValueObjects;

namespace PersonalHealthAPI.Extensions;

public static class FoodResponseMapper
{
	public static FoodResponse MapFoodResponse(this IEnumerable<Food> foods) => new()
	{
		Foods = foods.MapFoodDtos()
	};

	public static List<FoodDto> MapFoodDtos(this IEnumerable<Food> foods) =>
		foods.Select(food => new FoodDto()
		{
			Name = food.Name,
			Nutrients = food.Nutrients.MapNutrientDtos()
		}).ToList();


	public static List<NutrientDto> MapNutrientDtos(this IEnumerable<Nutrient> nutrients) =>
		nutrients.Select(nutrient => new NutrientDto()
		{
			Name = nutrient.Name,
			Weight = nutrient.Weight.Value,
			Unit = (UnitDto)nutrient.Weight.Unit
		}).ToList();
}