using SQLite;

namespace NutritionApp.Data;

[Table("search_history")]
internal class SearchFoodItem : FoodItemDto
{
    [Column("search_time")]
    public DateTime SearchTime { get; set; } = DateTime.Now;
}