using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MongoDB.EntityFrameworkCore.Extensions;
using NutritionTrackR.Core.Foods;

namespace NutritionTrackR.Persistence.Configurations;

public class FoodConfiguration : IEntityTypeConfiguration<Food>
{
	public void Configure(EntityTypeBuilder<Food> builder)
	{
		builder
			.ToCollection("Foods")
			.OwnsMany(f => f.Nutrients, nutrients =>
			{
				nutrients.OwnsOne(n => n.Weight, weight =>
				{
					weight.Property(x => x.Value)
						.HasConversion(typeof(double));
					weight.Property(x => x.Unit);
				});
			})
			.HasKey(f => f.Id);

		builder.Property(x => x.ExternalId);
	}
}