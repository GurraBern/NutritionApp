using NutritionTrackR.Contracts.Food;
using System.Text.Json;

namespace NutritionTrackR.Web.Components.Pages.FoodSearch;

public class FoodListAdapter
{
	private readonly IHttpClientFactory _factory;

	public FoodListAdapter(IHttpClientFactory factory)
	{
		_factory = factory;
	}

	public async Task<List<FoodDto>> GetFoodItems()
	{
		var client = CreateClient();

		var response = await client.GetAsync("api/v1/food");
		if (!response.IsSuccessStatusCode) //TODO show popup
			return [];

		var responseBody = await response.Content.ReadAsStringAsync();

		var foodResponse = JsonSerializer.Deserialize<FoodResponse>(responseBody);

		return foodResponse?.Foods ?? [];
	}

	public async Task<List<FoodDto>> GetFoodEntries()
	{
		var client = CreateClient();

		var response = await client.GetAsync("api/v1/food-log");
		if (!response.IsSuccessStatusCode) //TODO show popup
			return [];

		var responseBody = await response.Content.ReadAsStringAsync();

		var foodResponse = JsonSerializer.Deserialize<>(responseBody);

		return foodResponse?.Foods ?? [];
	}

	public HttpClient CreateClient()
	{
		var client = _factory.CreateClient(nameof(FoodListAdapter));

		return client;
	}
}