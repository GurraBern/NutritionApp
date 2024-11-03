using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;
using NutritionTrackR.Core.Foods;
using NutritionTrackR.Core.Foods.ValueObjects;

namespace NutritionTrackR.Persistence.Repositories;

public class FoodRepository(NutritionDbContext dbContext) : IFoodRepository
{
    public async Task CreateFood(Food food)
    {
        await dbContext.Foods.AddAsync(food);
    }

    public async Task<IEnumerable<Food>> Get(IEnumerable<FoodId> foodIds)
    {
        var ids = foodIds.Select(x => ObjectId.Parse(x.Id));
        return await dbContext.Foods
            .Where(x => ids.Contains(x.Id))
            .AsNoTracking()
            .ToListAsync();
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