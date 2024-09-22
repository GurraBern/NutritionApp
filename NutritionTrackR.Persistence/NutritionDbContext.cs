using Microsoft.EntityFrameworkCore;
using NutritionTrackR.Core.Food;

namespace NutritionTrackR.Persistence;

public class NutritionDbContext : DbContext
{
    public DbSet<Food> Foods { get; init; }
    
    public NutritionDbContext(DbContextOptions<NutritionDbContext> options) : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(NutritionDbContext).Assembly);
    }
}