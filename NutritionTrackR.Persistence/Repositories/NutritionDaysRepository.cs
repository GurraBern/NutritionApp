using Microsoft.EntityFrameworkCore;
using NutritionTrackR.Core.NutrientTracking;

namespace NutritionTrackR.Persistence.Repositories;

public class NutritionDaysRepository(NutritionDbContext dbContext) : IFoodLogRepository
{
	public async Task<IEnumerable<NutritionDay>> GetNutritionDays()
	{
		return await dbContext.NutritionDays.AsNoTracking().ToListAsync();
	}
}