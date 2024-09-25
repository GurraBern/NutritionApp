using NutritionTrackR.Core.Shared.Abstractions;

namespace NutritionTrackR.Persistence.Repositories;

public class EfUnitOfWork(NutritionDbContext dbContext) : IUnitOfWork
{
    public Task<int> SaveAsync()
    {
        return dbContext.SaveChangesAsync();
    }
}