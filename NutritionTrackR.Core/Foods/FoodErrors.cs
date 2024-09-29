using NutritionTrackR.Core.Shared.Abstractions;

namespace NutritionTrackR.Core.Food;

public static class FoodErrors
{
	public static readonly Error ZeroWeight = new Error("Weight must be greater than zero");
	public static readonly Error EmptyNutrientName = new Error("Nutrient name cannot be empty");
}