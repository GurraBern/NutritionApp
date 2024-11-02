using Microsoft.EntityFrameworkCore;
using NutritionTrackR.Core.Foods;
using NutritionTrackR.Core.Foods.Queries;

namespace NutritionTrackR.Persistence.Repositories;

public class FoodRepository(NutritionDbContext dbContext) : IFoodRepository
{
    public async Task CreateFood(Food food)
    {
        await dbContext.Foods.AddAsync(food);
    }

    public async Task<IEnumerable<Food>> Get(FoodsQueryFilter queryFilter)
    {
        return await dbContext.Foods.Where(x => queryFilter.FoodIds.Contains(x.Id)).AsNoTracking().ToListAsync();
    }

    public Task<IEnumerable<Food>> GetById(string id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Food>> GetAll()
    {
        return await dbContext.Foods
            .AsNoTracking()
            .ToListAsync();;
    }
}