using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;
using NutritionTrackR.Core.Nutrition.Tracking;

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
		return await dbContext.NutritionDays.SingleOrDefaultAsync(x => x.Date == date.Date);
	}
}