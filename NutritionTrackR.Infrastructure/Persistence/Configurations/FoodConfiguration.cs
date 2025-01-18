using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MongoDB.EntityFrameworkCore.Extensions;
using NutritionTrackR.Core.Foods;
using NutritionTrackR.Core.Shared.ValueObjects;

namespace NutritionTrackR.Infrastructure.Persistence.Configurations;

public class FoodConfiguration : IEntityTypeConfiguration<Food>
{
	public void Configure(EntityTypeBuilder<Food> builder)
	{
		builder
			.ToCollection("Foods")
			.OwnsMany(f => f.Nutrients, nutrients =>
			{
				nutrients.OwnsOne(n => n.Weight, weight => {
					weight.Property(x => x.Value);
					weight.Property(x => x.Unit)
						.HasConversion(w => w.Name, w => WeightUnit.FromString(w).Value);
				});
			})
			.HasKey(f => f.Id);

		builder.Property(x => x.ExternalId);
	}
}
