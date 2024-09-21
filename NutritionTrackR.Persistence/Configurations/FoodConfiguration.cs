using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NutritionTrackR.Core.Food;

namespace NutritionTrackR.Persistence.Configurations;

public class FoodConfiguration : IEntityTypeConfiguration<Food>
{
    public void Configure(EntityTypeBuilder<Food> builder)
    {
        builder.HasKey(f => f.Id);

        // builder
        //     .Property(f => f.Id)
        //     .HasConversion(foodId => foodId.Value, 
        //         value => new FoodId(value));
        // builder.Entity<Food>().ToCollection("foods")
    }
}