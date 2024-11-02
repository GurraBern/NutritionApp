using NutritionTrackR.Core.Shared.Abstractions;

namespace NutritionTrackR.Persistence;

public class EfUnitOfWork(NutritionDbContext dbContext) : IUnitOfWork
{
    public Task<int> SaveAsync()
    {
        return dbContext.SaveChangesAsync();
    }
}