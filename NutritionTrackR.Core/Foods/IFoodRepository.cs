using NutritionTrackR.Core.Foods.ValueObjects;

namespace NutritionTrackR.Core.Foods;

public interface IFoodRepository
{
    Task CreateFood(Food food);
    Task<IEnumerable<Food>> GetAll();
    Task<IEnumerable<Food>> Get(IEnumerable<FoodId> foodIds);
    Task<IEnumerable<Food>> GetById(string id);
}