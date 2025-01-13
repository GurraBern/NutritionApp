using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MongoDB.Bson;
using MongoDB.EntityFrameworkCore.Extensions;
using NutritionTrackR.Core.Foods.ValueObjects;
using NutritionTrackR.Core.Nutrition.Tracking;
using NutritionTrackR.Core.Shared.ValueObjects;

namespace NutritionTrackR.Persistence.Configurations;

public class NutritionDayConfiguration : IEntityTypeConfiguration<NutritionDay>
{
    public void Configure(EntityTypeBuilder<NutritionDay> builder)
    {
        builder.HasKey(n => n.Id);

        builder.OwnsMany(n => n.ConsumedFood, o =>
        {
            o.Property(x => x.LoggedFoodId);
            
            o.Property(x => x.FoodId)
                .HasConversion(
                v => ObjectId.Parse(v.Id),
                v => new FoodId(v.ToString()));

            o.OwnsOne(x => x.Weight, w =>
            {
                w.Property(p => p.Value);
                w.Property(p => p.Unit).HasConversion(
                    w => w.Name,
                    w => WeightUnit.FromString(w).Value);
            });
        });

        builder.Property(x => x.Date);

        builder.ToCollection("NutritionDays");
    }
}