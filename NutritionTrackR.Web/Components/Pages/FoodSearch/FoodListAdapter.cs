using NutritionTrackR.Contracts;
using NutritionTrackR.Contracts.Food;
using NutritionTrackR.Contracts.Shared;
using System.Text.Json;
using System.Text.Json.Serialization;

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
		if (response.IsSuccessStatusCode)
		{
			var responseBody = await response.Content.ReadAsStringAsync();
			var foods = JsonSerializer.Deserialize<ApiResponse<FoodResponse>>(responseBody).Data;

			return foods.Foods;
		}

		//TODO show error message
		return [];
	}

	public HttpClient CreateClient()
	{
		var client = _factory.CreateClient(nameof(FoodListAdapter));

		return client;
	}
}