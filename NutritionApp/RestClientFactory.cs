using RestSharp;

namespace NutritionApp;

public class RestClientFactory
{
    public static IRestClient CreateRestClient(string baseUrl)
    {
        var options = new RestClientOptions(baseUrl);
        return new RestClient(options);
    }
}
