using MediatR;
using Microsoft.EntityFrameworkCore;
using NutritionTrackR.Core.Shared;
using NutritionTrackR.Core.Shared.Abstractions;

namespace NutritionTrackR.Core.Foods.Queries;

public record GetFoodsQuery(FoodsQueryFilter Filter) : IRequest<Result<IEnumerable<Food>>>;

public class GetFoodsHandler(INutritionDbContext dbContext) : IRequestHandler<GetFoodsQuery, Result<IEnumerable<Food>>>
{
	public async Task<Result<IEnumerable<Food>>> Handle(GetFoodsQuery query, CancellationToken cancellationToken = default)
	{
		var foods = await dbContext.Foods
			.Where(f => f.Name.Contains(query.Filter.Name, StringComparison.CurrentCultureIgnoreCase))
            .AsNoTracking()
            .ToListAsync(cancellationToken);
		
		return Result.Success<IEnumerable<Food>>(foods);
	}
}