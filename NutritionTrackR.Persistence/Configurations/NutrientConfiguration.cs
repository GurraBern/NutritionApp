// using Microsoft.EntityFrameworkCore;
// using Microsoft.EntityFrameworkCore.Metadata.Builders;
// using MongoDB.EntityFrameworkCore.Extensions;
// using NutritionTrackR.Core.Food;
// using NutritionTrackR.Core.Food.ValueObjects;
//
// namespace NutritionTrackR.Persistence.Configurations;
//
// public class NutrientConfiguration : IEntityTypeConfiguration<Nutrient>{
//
// 	public void Configure(EntityTypeBuilder<Nutrient> builder)
// 	{
// 		builder.ToCollection("Nutrients");
//
// 		builder.HasMany<Food>();
// 		
// 		builder.HasKey(n => n.Id);
// 		//
// 		// builder.ComplexProperty(x => x.Weight, v =>
// 		// 	v.Property(p => p.Value)
// 		// 		.IsRequired());
// 	}
// }