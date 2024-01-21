using Nutrition.Core;
using RestSharp;

namespace NutritionApp.Services.NutritionServices;

public interface INutritionApiClient
{
    Task<IEnumerable<FoodItem>> GetAsync(RestRequest request, string bearerToken);
}