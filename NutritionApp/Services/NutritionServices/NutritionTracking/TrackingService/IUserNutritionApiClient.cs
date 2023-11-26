using Nutrition.Core;
using RestSharp;

namespace NutritionApp.Services.NutritionServices;

public interface IUserNutritionApiClient
{
    Task<NutritionDay> GetAsync(RestRequest request, string bearerToken);

    Task<NutritionDay> PostAsync(RestRequest request, string bearerToken);
}