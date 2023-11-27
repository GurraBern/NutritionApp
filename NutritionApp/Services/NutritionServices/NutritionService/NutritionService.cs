using Nutrition.Core;
using NutritionApp.Data;
using RestSharp;

namespace NutritionApp.Services.NutritionServices;

public class NutritionService : INutritionService
{
    private readonly INutritionApiClient client;
    private readonly IAuthService authService;
    private readonly IDataRepository dataRepository;

    public NutritionService(INutritionApiClient client, IAuthService authService, IDataRepository dataRepository)
    {
        this.client = client;
        this.authService = authService;
        this.dataRepository = dataRepository;
    }

    public async Task<IEnumerable<FoodItem>> GetSearchResults(string query)
    {
        try
        {
            var request = new RestRequest($"api/Food/name/{query}");
            var searchResults = await client.GetAsync(request, authService.CurrentUser.Credential.IdToken);
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
            var foods = await client.GetAsync(request, authService.CurrentUser.Credential.IdToken);
            return foods;
        }
        catch (Exception e)
        {
            throw;
        }
    }
}