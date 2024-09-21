using System.ComponentModel.DataAnnotations;

namespace NutritionTrackR.Persistence;

public class DatabaseSettings
{
    [Required]
    public string ConnectionString { get; set; } = null!;
}