using FluentResults;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NutritionTrackR.Core.Shared;

namespace NutritionTrackR.Core.Foods.Queries;

public record GetFoodsQuery(FoodsQueryFilter Filter) : IRequest<Result<List<Food>>>;

public class GetFoodsHandler(INutritionDbContext dbContext) : IRequestHandler<GetFoodsQuery, Result<List<Food>>>
{
	public async Task<Result<List<Food>>> Handle(GetFoodsQuery query, CancellationToken cancellationToken = default)
	{
		var foods = await dbContext.Foods
			.Where(f => f.Name.Contains(query.Filter.Name, StringComparison.CurrentCultureIgnoreCase))
            .AsNoTracking()
            .ToListAsync(cancellationToken);
		
		return Result.Ok(foods);
	}
}