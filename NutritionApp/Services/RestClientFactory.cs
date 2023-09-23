using RestSharp;

namespace NutritionApp.Services;

public class RestClientFactory
{
    public static IRestClient CreateRestClient(string baseUrl)
    {
        var options = new RestClientOptions(baseUrl);
        return new RestClient(options);
    }
}
