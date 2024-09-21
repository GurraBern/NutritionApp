using NutritionTrackR.Core.Food;

namespace NutritionTrackR.Persistence.Repositories;

public class FoodRepository(NutritionDbContext dbContext) : IFoodRepository
{
    public async Task CreateFood(Food food)
    {
        await dbContext.Foods.AddAsync(food);
    }
}