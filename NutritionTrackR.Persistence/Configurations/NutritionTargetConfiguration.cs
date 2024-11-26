using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NutritionTrackR.Core.Nutrition.Target;

namespace NutritionTrackR.Persistence.Configurations;

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
                w.Property(p => p.Unit);
            });
        });
    }
}