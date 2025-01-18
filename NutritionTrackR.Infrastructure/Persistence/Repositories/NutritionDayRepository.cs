using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;
using NutritionTrackR.Core.Nutrition.Tracking;
using NutritionTrackR.Core.Shared;

namespace NutritionTrackR.Infrastructure.Persistence.Repositories;

public class NutritionDayRepository(INutritionDbContext dbContext) : INutritionDayRepository
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