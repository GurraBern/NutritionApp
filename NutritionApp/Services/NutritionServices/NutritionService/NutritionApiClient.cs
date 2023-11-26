using Nutrition.Core;
using RestSharp;

namespace NutritionApp.Services.NutritionServices;

public class NutritionApiClient : INutritionApiClient
{
    private readonly IRestClient restClient;

    public NutritionApiClient(string baseUrl)
    {
        restClient = new RestClient(baseUrl);
    }

    public async Task<IEnumerable<FoodItem>> GetAsync(RestRequest request, string bearerToken)
    {
        request.AddHeader("Authorization", $"Bearer {bearerToken}");
        return await restClient.GetAsync<IEnumerable<FoodItem>>(request);
    }
}