using Microsoft.EntityFrameworkCore;
using NutritionTrackR.Core.Food;
using NutritionTrackR.Core.Food.Queries;
using NutritionTrackR.Core.Foods;

namespace NutritionTrackR.Persistence.Repositories;

public class FoodRepository(NutritionDbContext dbContext) : IFoodRepository
{
    public async Task CreateFood(Food food)
    {
        await dbContext.Foods.AddAsync(food);
    }

    public async Task<IEnumerable<Food>> GetAll(FoodsQueryFilter queryFilter)
    {
        return await dbContext.Foods
            .AsNoTracking()
            .ToListAsync();;
    }
}