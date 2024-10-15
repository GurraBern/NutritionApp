using MediatR;
using NutritionTrackR.Core.Foods;
using NutritionTrackR.Core.Foods.Queries;
using NutritionTrackR.Core.Shared.Abstractions;

namespace NutritionTrackR.Core.NutrientTracking.Queries;

public record GetLoggedFoodsQuery(FoodsQueryFilter Filter) : IRequest<Result<LoggedFoodResponse>>;

public record LoggedFoodResponse(List<Foods.Food> Foods);

public class GetNutritionDaysHandler(INutritionDayRepository repository, IFoodRepository foodRepository) : IRequestHandler<GetLoggedFoodsQuery, Result<LoggedFoodResponse>>
{
	public async Task<Result<LoggedFoodResponse>> Handle(GetLoggedFoodsQuery query, CancellationToken cancellationToken)
	{
		var nutritionDay = await repository.GetByDate(query.Filter.Date);
		if (nutritionDay == null)
			return Result.Success(new LoggedFoodResponse([]));

		var foods = await foodRepository.Get(query.Filter);

		return Result.Success(new LoggedFoodResponse(foods.ToList()));
	}
}