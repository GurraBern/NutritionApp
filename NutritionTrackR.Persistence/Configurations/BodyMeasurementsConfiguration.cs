using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MongoDB.EntityFrameworkCore.Extensions;
using NutritionTrackR.Core.BodyMeasurements;
using NutritionTrackR.Core.BodyMeasurements.ValueObjects;
using NutritionTrackR.Core.Shared.ValueObjects;

namespace NutritionTrackR.Persistence.Configurations;

public class BodyMeasurementsConfiguration : IEntityTypeConfiguration<BodyMeasurement>
{

    public void Configure(EntityTypeBuilder<BodyMeasurement> builder)
    {
        builder.ToCollection("BodyMeasurements");
        builder.HasKey(m => m.Id);

        builder.Property(m => m.Date);
        
        builder.OwnsOne(m => m.Weight, weight => {
            weight.Property(x => x.Value)
                .HasConversion<double>();
            
            weight.Property(x => x.Unit).HasConversion(
            w => w.Name,
            w => WeightUnit.FromString(w).Value);
        });

        builder.OwnsMany(m => m.Measurements, x => {

            x.Property(y => y.Length);
            x.Property(y => y.Unit).HasConversion(
            t => t.Name, 
            t => MeasurementUnit.FromString(t)); //TODO .Value
        });
    }
}