using Nutrition.Core;
using RestSharp;

namespace NutritionApp.Services.NutritionServices;

public class UserNutritionApiClient(IRestClient restClient) : IUserNutritionApiClient
{
    private readonly IRestClient restClient = restClient;

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

public interface IUserNutritionApiClient
{
    Task<NutritionDay> GetAsync(RestRequest request, string bearerToken);

    Task<NutritionDay> PostAsync(RestRequest request, string bearerToken);
}