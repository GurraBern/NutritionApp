using MediatR;
using NutritionTrackR.Core.NutrientTracking.Events;
using NutritionTrackR.Core.Shared.Abstractions;

namespace NutritionTrackR.Core.NutrientTracking.Queries;

public record GetLoggedFoodsQuery(DateTimeOffset Date) : IRequest<Result<LoggedFoodResponse>>;

public record LoggedFoodResponse(IEnumerable<FoodLoggedEvent> Foods);

public class GetNutritionDaysHandler(IFoodLogRepository repository) : IRequestHandler<GetLoggedFoodsQuery, Result<LoggedFoodResponse>>
{
	public async Task<Result<LoggedFoodResponse>> Handle(GetLoggedFoodsQuery request, CancellationToken cancellationToken)
	{
		var nutritionDays = await repository.GetNutritionDays();

		// var response = new LoggedFoodResponse(nutritionDays);

		return Result.Success(new LoggedFoodResponse([]));
	}
}