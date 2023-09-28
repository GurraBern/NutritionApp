using NutritionApp.MVVM.Models;
using RestSharp;

namespace NutritionApp.Services.NutritionServices;

public class NutritionService : INutritionService
{
    private readonly IRestClient client;
    public NutritionService(IRestClient client)
    {
        this.client = client;
    }

    public async Task<IEnumerable<FoodItem>> GetSearchResults(string query)
    {
        try
        {
            var request = new RestRequest($"api/Food/name/{query}");
            var searchResults = await client.GetAsync<IEnumerable<FoodItem>>(request);
            return searchResults;
        }
        catch (Exception e)
        {
            throw;
        }
    }

    public async Task<IEnumerable<FoodItem>> GetFood()
    {
        try
        {
            var request = new RestRequest("api/Food");
            var test = await client.ExecuteAsync(request);

            var foods = await client.GetAsync<IEnumerable<FoodItem>>(request);
            return foods;
        }
        catch (Exception e)
        {

            throw;
        }
    }
}
