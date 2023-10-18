using RestSharp;

namespace NutritionApp.Services.NutritionServices;

public class NutritionApiClient : RestClient
{
    public NutritionApiClient(string baseUrl) : base(baseUrl)
    {

    }

    public async Task<T> GetAsync<T>(RestRequest request, string bearerToken)
    {
        request.AddHeader("Authorization", $"Bearer {bearerToken}");
        return await this.GetAsync<T>(request);
    }
}
