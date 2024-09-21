using Microsoft.EntityFrameworkCore;
using MongoDB.EntityFrameworkCore.Extensions;
using NutritionTrackR.Core.Food;

namespace NutritionTrackR.Persistence;

public class NutritionDbContext : DbContext
{
    public NutritionDbContext(DbContextOptions<NutritionDbContext> options) : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(NutritionDbContext).Assembly);
        
        modelBuilder.Entity<Food>().ToCollection("foods");
    }

    public DbSet<Food> Foods { get; set; }
}