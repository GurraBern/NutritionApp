using Nutrition.Core;
using RestSharp;

namespace NutritionApp.Services.NutritionServices;

public class UserNutritionApiClient(string baseUrl) : IUserNutritionApiClient
{
    private readonly RestClient restClient = new(baseUrl);

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