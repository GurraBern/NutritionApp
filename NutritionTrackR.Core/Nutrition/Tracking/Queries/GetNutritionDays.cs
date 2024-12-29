using MediatR;
using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;
using NutritionTrackR.Core.Foods;
using NutritionTrackR.Core.Foods.Queries;
using NutritionTrackR.Core.Shared;

namespace NutritionTrackR.Core.Nutrition.Tracking.Queries;

public record GetLoggedFoodsQuery(FoodsQueryFilter Filter) : IRequest<LoggedFoodResponse>;

public record LoggedFoodResponse(IEnumerable<LoggedFood> LoggedFoods, IEnumerable<Food> Foods);

public class GetNutritionDays(INutritionDbContext dbContext, INutritionDayRepository repository) : IRequestHandler<GetLoggedFoodsQuery, LoggedFoodResponse>
{
    public async Task<LoggedFoodResponse> Handle(GetLoggedFoodsQuery query, CancellationToken cancellationToken)
    {
        var nutritionDay = await repository.GetByDate(query.Filter.Date);
        if (nutritionDay == null)
            return new LoggedFoodResponse([], []);

        var foodIds = nutritionDay.ConsumedFood
            .Select(x => ObjectId.Parse(x.FoodId.Id));
        
        var foods = await dbContext.Foods
            .Where(x => foodIds.Contains(x.Id))
            .AsNoTracking()
            .ToListAsync(cancellationToken: cancellationToken);

        return new LoggedFoodResponse(nutritionDay.ConsumedFood, foods);
    }
}