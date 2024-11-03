using NutritionTrackR.Contracts.Food;
using System.Text.Json;

namespace NutritionTrackR.Web.Components.Services;

public class FoodListAdapter(IHttpClientFactory factory)
{
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

	public async Task<List<FoodDto>> GetLoggedFood()
	{
		var client = CreateClient();
		try
		{
			var response = await client.GetAsync("api/v1/food-log");
			response.EnsureSuccessStatusCode(); // TODO unnecessary

			var responseBody = await response.Content.ReadAsStringAsync();

			var foodResponse = JsonSerializer.Deserialize<FoodResponse>(responseBody);

			return foodResponse.Foods;
		}
		catch (Exception e)
		{
			//TODO Display error
			return [];
		}
	}

	private HttpClient CreateClient()
	{
		var client = factory.CreateClient(nameof(FoodListAdapter));

		return client;
	}
}