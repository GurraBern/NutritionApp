using Microsoft.EntityFrameworkCore;
using NutritionTrackR.Core.BodyMeasurements.Events;
using NutritionTrackR.Core.Foods;
using NutritionTrackR.Core.Nutrition.Target;
using NutritionTrackR.Core.Nutrition.Tracking;

namespace NutritionTrackR.Core.Shared;

public interface INutritionDbContext
{
    DbSet<Food> Foods { get; }
    DbSet<NutritionDay> NutritionDays { get; }
    DbSet<NutritionTarget> NutritionTargets { get; }
    DbSet<WeightEvent> BodyWeights { get; init; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}