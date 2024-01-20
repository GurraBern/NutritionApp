using RestSharp;

namespace NutritionApp.Data.Services.ApiClients;

public class UserMeasurementsApiClient(IRestClient restClient) : IUserMeasurementsApiClient
{
    private readonly IRestClient restClient = restClient;

    public async Task<double> GetAsync(RestRequest request, string bearerToken)
    {
        request.AddHeader("Authorization", $"Bearer {bearerToken}");
        return await restClient.GetAsync<double>(request);
    }

    public async Task PostAsync(RestRequest request, string bearerToken)
    {
        request.AddHeader("Authorization", $"Bearer {bearerToken}");
        await restClient.PostAsync<double>(request);
    }
}

public interface IUserMeasurementsApiClient
{
    Task<double> GetAsync(RestRequest request, string bearerToken);

    Task PostAsync(RestRequest request, string bearerToken);
}