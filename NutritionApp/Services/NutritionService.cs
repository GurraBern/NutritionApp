using NutritionApp.MVVM.Models;
using RestSharp;

namespace NutritionApp.Services;

public class NutritionService : INutritionService
{
    private readonly IRestClient client;
    public NutritionService(IRestClient client)
    {
        this.client = client;
    }

    public async Task<IEnumerable<FoodItem>> GetSearchResults(string query)
    {
        var request = new RestRequest($"/api/Food/name/{query}");
        var searchResults = await client.GetAsync<IEnumerable<FoodItem>>(request);

        return searchResults;
    }
}
