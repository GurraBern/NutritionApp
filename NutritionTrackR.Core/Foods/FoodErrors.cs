using NutritionTrackR.Core.Shared.Abstractions;

namespace NutritionTrackR.Core.Foods;

public static class FoodErrors
{
	public static readonly Error ZeroWeight = new("Weight must be greater than zero");
	public static readonly Error EmptyNutrientName = new("Nutrient name cannot be empty");
}