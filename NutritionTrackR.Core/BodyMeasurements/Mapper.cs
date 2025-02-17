using NutritionTrackR.Contracts.BodyMeasurement;
using NutritionTrackR.Core.BodyMeasurements.Events;

namespace NutritionTrackR.Core.BodyMeasurements;

public static class Mapper
{
	public static IEnumerable<WeightDto> ToDto(this IEnumerable<WeightEvent> weightEvents)
	{
		return weightEvents.Select(x => new WeightDto(x.Weight.Value, x.Weight.Unit.Unit.ToString()));
	}
}