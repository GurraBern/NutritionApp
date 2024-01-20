using Nutrition.Core;
using RestSharp;

namespace NutritionApp.Services.NutritionServices;

public class NutritionApiClient(string baseUrl) : INutritionApiClient
{
    private readonly IRestClient restClient = new RestClient(baseUrl);

    public async Task<IEnumerable<FoodItem>> GetAsync(RestRequest request, string bearerToken)
    {
        request.AddHeader("Authorization", $"Bearer {bearerToken}");
        return await restClient.GetAsync<IEnumerable<FoodItem>>(request);
    }
}