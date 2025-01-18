using System.ComponentModel.DataAnnotations;

namespace NutritionTrackR.Infrastructure.Persistence;

public class DatabaseSettings
{
    [Required]
    public string ConnectionString { get; set; } = null!;
}