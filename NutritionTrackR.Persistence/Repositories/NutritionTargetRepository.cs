using Microsoft.EntityFrameworkCore;
using NutritionTrackR.Core.Nutrition.Target;
using NutritionTrackR.Core.Shared;

namespace NutritionTrackR.Persistence.Repositories;

public class NutritionTargetRepository(INutritionDbContext dbContext) : INutritionTargetRepository
{
    //TODO should we be able to set future nutrition targets? Maybe get the most recent nutrition target from the past.
    
    public async Task<NutritionTarget?> GetNutritionTarget()
    {
        return await dbContext.NutritionTargets
            .OrderByDescending(x => x.ActivationDate)
            .AsNoTracking()
            .FirstOrDefaultAsync();
    }
    
    public async Task<NutritionTarget?> GetNutritionTarget(DateTime date)
    {
        return await dbContext.NutritionTargets
            .SingleOrDefaultAsync(x => x.ActivationDate == date.Date);
    }
    

    public async Task Add(NutritionTarget nutritionTarget)
    {
        await dbContext.NutritionTargets.AddAsync(nutritionTarget);
    }
}