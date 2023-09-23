namespace NutritionApp.MVVM.Models;

public interface ISettingsService
{
    Task<T> Get<T>(string key, T defaultValue);
    Task<T> Save<T>(string key, T value);
}