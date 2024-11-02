using NutritionTrackR.Core.Foods.Queries;

namespace NutritionTrackR.Core.Foods;

public interface IFoodRepository
{
    Task CreateFood(Food food);
    Task<IEnumerable<Food>> GetAll();
    Task<IEnumerable<Food>> Get(FoodsQueryFilter queryFilter);
    Task<IEnumerable<Food>> GetById(string id);
}