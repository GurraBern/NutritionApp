using NutritionTrackR.Core.Food.Queries;

namespace NutritionTrackR.Core.Food;

public interface IFoodRepository
{
    Task CreateFood(Food food);
    Task<IEnumerable<Food>> GetAll(FoodsQueryFilter queryFilter);
}