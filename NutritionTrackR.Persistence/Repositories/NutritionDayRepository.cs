using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;
using NutritionTrackR.Core.NutrientTracking;

namespace NutritionTrackR.Persistence.Repositories;

public class NutritionDayRepository(NutritionDbContext dbContext) : INutritionDayRepository
{
	public Task<NutritionDay?> GetById(string id)
	{
		return dbContext.NutritionDays.SingleOrDefaultAsync(x => x.Id.Equals(ObjectId.Parse(id)));
	}

	public Task<int> SaveAsync()
	{
		return dbContext.SaveChangesAsync();
	}

	public async Task Create(NutritionDay nutritionDay)
	{
		await dbContext.NutritionDays.AddAsync(nutritionDay);
	}

	public async Task<NutritionDay?> GetByDate(DateTime date)
	{
		return await dbContext.NutritionDays
			.FirstOrDefaultAsync(nutritionDay => nutritionDay.Date >= date.Date.Date && 
			                                     nutritionDay.Date <= date.Date.AddDays(1).AddTicks(-1));
	}
}