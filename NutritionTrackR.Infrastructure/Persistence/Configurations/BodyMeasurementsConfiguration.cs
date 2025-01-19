using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MongoDB.EntityFrameworkCore.Extensions;
using NutritionTrackR.Core.BodyMeasurements.Events;
using NutritionTrackR.Core.Shared.ValueObjects;

namespace NutritionTrackR.Infrastructure.Persistence.Configurations;

public class BodyMeasurementsConfiguration : IEntityTypeConfiguration<WeightEvent>
{
    public void Configure(EntityTypeBuilder<WeightEvent> builder)
    {
	    builder.ToCollection("BodyMeasurements")
		    .HasDiscriminator<string>("Discriminator")
		    .HasValue<WeightTracked>(nameof(WeightTracked));
        
        builder.HasKey(m => m.Id);

		builder.Property(x => x.Descriptor);
		
        builder.HasIndex(x => x.UserId);
		builder.Property(x => x.UserId);
		
        builder.Property(m => m.OccuredAt);
        
		builder.OwnsOne(n => n.Weight, weight => {
			weight.Property(x => x.Value);
			weight.Property(x => x.Unit)
				.HasConversion(w => w.Name, w => WeightUnit.FromString(w).Value);
		});
    }
}