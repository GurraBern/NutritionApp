using Nutrition.Core;
using RestSharp;

namespace NutritionApp.Services.NutritionServices;

public class NutritionApiClient : INutritionApiClient
{
    private readonly RestClient restClient;

    public NutritionApiClient(string baseUrl)
    {
        restClient = new RestClient(baseUrl);
    }

    public async Task<NutritionDay> GetAsync(RestRequest request, string bearerToken)
    {
        request.AddHeader("Authorization", $"Bearer {bearerToken}");
        return await restClient.GetAsync<NutritionDay>(request);
    }

    public async Task<NutritionDay> PostAsync(RestRequest request, string bearerToken)
    {
        request.AddHeader("Authorization", $"Bearer {bearerToken}");
        return await restClient.PostAsync<NutritionDay>(request);
    }
}
