using Microsoft.Maui.Storage;
using NutritionApp.MVVM.Models;
using System.Threading.Tasks;

namespace NutritionApp.Services;

public class SettingsService : ISettingsService
{
    public Task<T> Get<T>(string key, T defaultValue)
    {
        var result = Preferences.Default.Get(key, defaultValue);
        return Task.FromResult(result);
    }

    public Task<T> Save<T>(string key, T value)
    {
        Preferences.Default.Set(key, value);
        return Task.FromResult(value);
    }
}
