﻿using Microsoft.EntityFrameworkCore;
using NutritionTrackR.Core.BodyMeasurements.Events;
using NutritionTrackR.Core.Foods;
using NutritionTrackR.Core.Nutrition.Target;
using NutritionTrackR.Core.Nutrition.Tracking;
using NutritionTrackR.Core.Shared;

namespace NutritionTrackR.Infrastructure.Persistence;

public class NutritionDbContext(DbContextOptions<NutritionDbContext> options) : DbContext(options), INutritionDbContext
{
    public DbSet<Food> Foods { get; init; }
    public DbSet<NutritionDay> NutritionDays { get; init; }
    public DbSet<NutritionTarget> NutritionTargets { get; init; }
    public DbSet<WeightEvent> BodyWeights { get; init; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(NutritionDbContext).Assembly);
    }
}