using System.ComponentModel.DataAnnotations;

namespace NutritionTrackR.Web.Configuration;

public class NutritionTrackRApiSettings
{
    [Required]
    public string BaseAddress { get; set; }
}