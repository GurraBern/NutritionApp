using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MongoDB.EntityFrameworkCore.Extensions;
using NutritionTrackR.Core.Nutrition.Target;
using NutritionTrackR.Core.Shared.ValueObjects;

namespace NutritionTrackR.Infrastructure.Persistence.Configurations;

public class NutritionTargetConfiguration : IEntityTypeConfiguration<NutritionTarget>
{
    public void Configure(EntityTypeBuilder<NutritionTarget> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.ActivationDate);

        builder.OwnsMany(n => n.Nutrients, o => 
        {
            o.OwnsOne(x => x.Weight, w =>
            {
                w.Property(p => p.Value);
                w.Property(p => p.Unit).HasConversion(
                    weightUnit => weightUnit.Name,
                    weightUnit => WeightUnit.FromString(weightUnit).Value);
            });
        });
        
        builder.ToCollection("NutritionTargets");
    }
}