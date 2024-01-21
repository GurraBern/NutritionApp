using Nutrition.Core;
using RestSharp;

namespace NutritionApp.Services.NutritionServices;

public class NutritionApiClient(IRestClient restClient) : INutritionApiClient
{
    private readonly IRestClient _restClient = restClient;

    public async Task<IEnumerable<FoodItem>> GetAsync(RestRequest request, string bearerToken)
    {
        request.AddHeader("Authorization", $"Bearer {bearerToken}");
        return await _restClient.GetAsync<IEnumerable<FoodItem>>(request);
    }
}