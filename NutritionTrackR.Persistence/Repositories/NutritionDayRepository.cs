using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;
using NutritionTrackR.Core.NutrientTracking;

namespace NutritionTrackR.Persistence.Repositories;

public class NutritionDayRepository : INutritionDayRepository
{
	private readonly NutritionDbContext _dbContext;

	public NutritionDayRepository(NutritionDbContext dbContext)
	{
		_dbContext = dbContext;
	}

	public Task<NutritionDay?> GetById(string id)
	{
		return _dbContext.NutritionDays.SingleOrDefaultAsync(x => x.Id.Equals(ObjectId.Parse(id)));
	}

	public Task<int> SaveAsync()
	{
		return _dbContext.SaveChangesAsync();
	}

	public async Task Create(NutritionDay nutritionDay)
	{
		await _dbContext.NutritionDays.AddAsync(nutritionDay);
	}
}
