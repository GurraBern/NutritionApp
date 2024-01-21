using RestSharp;

namespace NutritionApp.Data.Services;

public class PersonalHealthApiClient<T>(IRestClient restClient) : IPersonalHealthApiClient<T>
{
    private readonly IRestClient restClient = restClient;

    public async Task<T> GetAsync(RestRequest request, string bearerToken)
    {
        request.AddHeader("Authorization", $"Bearer {bearerToken}");
        return await restClient.GetAsync<T>(request);
    }

    public async Task<T> PostAsync(RestRequest request, string bearerToken)
    {
        request.AddHeader("Authorization", $"Bearer {bearerToken}");
        return await restClient.PostAsync<T>(request);
    }
}

public interface IPersonalHealthApiClient<T>
{
    Task<T> GetAsync(RestRequest request, string bearerToken);

    Task<T> PostAsync(RestRequest request, string bearerToken);
}