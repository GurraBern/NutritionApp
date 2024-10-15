using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MongoDB.EntityFrameworkCore.Extensions;
using NutritionTrackR.Core.NutrientTracking;

namespace NutritionTrackR.Persistence.Configurations;

public class NutritionDayConfiguration : IEntityTypeConfiguration<NutritionDay>
{

	public void Configure(EntityTypeBuilder<NutritionDay> builder)
	{
		builder.HasKey(n => n.Id);

		builder
			.ToCollection("NutritionDays")
			.OwnsMany(n => n.DomainEvents);

		builder.Property(x => x.Date);

		// builder.Ignore(n => n.NutritionDayState);


	}
}