using Microsoft.EntityFrameworkCore;
using NutritionTrackR.Core.Nutrition.Target;

namespace NutritionTrackR.Persistence.Repositories;

public class NutritionTargetRepository(NutritionDbContext dbContext) : INutritionTargetRepository
{
    public Task<NutritionTarget?> GetNutritionTarget(DateTime date)
    {
        return dbContext.NutritionTargets.SingleOrDefaultAsync(x => x.ActivationDate == date.Date);
    }

    public async Task Add(NutritionTarget nutritionTarget)
    {
        await dbContext.NutritionTargets.AddAsync(nutritionTarget);
    }
}