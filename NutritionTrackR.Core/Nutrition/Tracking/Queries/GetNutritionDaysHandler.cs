using MediatR;
using NutritionTrackR.Core.Foods;
using NutritionTrackR.Core.Foods.Queries;

namespace NutritionTrackR.Core.Nutrition.Tracking.Queries;

public record GetLoggedFoodsQuery(FoodsQueryFilter Filter) : IRequest<LoggedFoodResponse>;

public record LoggedFoodResponse(IEnumerable<LoggedFood> LoggedFoods, IEnumerable<Food> Foods);

public class GetNutritionDaysHandler(INutritionDayRepository repository, IFoodRepository foodRepository) : IRequestHandler<GetLoggedFoodsQuery, LoggedFoodResponse>
{
    public async Task<LoggedFoodResponse> Handle(GetLoggedFoodsQuery query, CancellationToken cancellationToken)
    {
        var nutritionDay = await repository.GetByDate(query.Filter.Date);
        if (nutritionDay == null)
            return new LoggedFoodResponse([], []);

        var consumedFood = nutritionDay.ConsumedFood;

        var foodIds = consumedFood.Select(x => x.FoodId);
        var foods = await foodRepository.Get(foodIds);

        return new LoggedFoodResponse(consumedFood, foods);
    }
}