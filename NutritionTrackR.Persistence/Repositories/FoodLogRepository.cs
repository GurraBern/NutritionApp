using Microsoft.EntityFrameworkCore;
using NutritionTrackR.Core.NutrientTracking;

namespace NutritionTrackR.Persistence.Repositories;

public class FoodLogRepository(NutritionDbContext dbContext) : IFoodLogRepository
{
	public async Task<IEnumerable<NutritionDay>> GetNutritionDays()
	{
		return await dbContext.NutritionDays.AsNoTracking().ToListAsync();
	}

	public async Task<NutritionDay?> GetByDate(DateTime date)
	{
		return await dbContext.NutritionDays
			.FirstOrDefaultAsync(nutritionDay => 
				nutritionDay.Date.Date == date.Date.Date);
	}

}