using Microsoft.EntityFrameworkCore;
using NutritionTrackR.Core.Foods;
using NutritionTrackR.Core.NutrientTracking;
using NutritionTrackR.Core.Nutrition.Tracking;

namespace NutritionTrackR.Persistence;

public class NutritionDbContext(DbContextOptions<NutritionDbContext> options) : DbContext(options)
{
    public DbSet<Food> Foods { get; init; }
    public DbSet<NutritionDay> NutritionDays { get; init; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(NutritionDbContext).Assembly);
    }
}