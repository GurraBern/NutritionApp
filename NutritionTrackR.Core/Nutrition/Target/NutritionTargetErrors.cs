using NutritionTrackR.Core.Shared.Abstractions;

namespace NutritionTrackR.Core.Nutrition.Target;

public class NutritionTargetErrors
{
	public static readonly Error NoExistingNutritionTargets = new("No existing nutrition targets");
}