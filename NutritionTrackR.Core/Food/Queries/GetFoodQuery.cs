using FluentResults;
using MediatR;

namespace NutritionTrackR.Core.Food.Queries;

public record GetFoodsQuery(FoodsQueryFilter Filter) : IRequest<Result<IEnumerable<Food>>>;

public class GetFoodsHandler(IFoodRepository repository) : IRequestHandler<GetFoodsQuery, Result<IEnumerable<Food>>>
{
	public async Task<Result<IEnumerable<Food>>> Handle(GetFoodsQuery query, CancellationToken cancellationToken)
	{
		var foods = await repository.GetAll(query.Filter);

		return Result.Ok(foods);
	}
}