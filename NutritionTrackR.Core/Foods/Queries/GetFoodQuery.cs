using MediatR;
using NutritionTrackR.Core.Shared.Abstractions;

namespace NutritionTrackR.Core.Foods.Queries;

public record GetFoodsQuery(FoodsQueryFilter Filter) : IRequest<Result<IEnumerable<Food>>>;

public class GetFoodsHandler(IFoodRepository repository) : IRequestHandler<GetFoodsQuery, Result<IEnumerable<Food>>>
{
	public async Task<Result<IEnumerable<Food>>> Handle(GetFoodsQuery query, CancellationToken cancellationToken)
	{
		var foods = await repository.GetAll();

		return Result.Success(foods);
	}
}