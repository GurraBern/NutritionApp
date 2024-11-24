using NutritionTrackR.Contracts.Food;
using System.Text.Json;
using NutritionTrackR.Contracts.NutritionTracking;
using NutritionTrackR.Web.Components.Pages.FoodSearch.AddFood;

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

	public async Task<List<FoodDto>> GetLoggedFood(DateOnly date)
	{
		var client = CreateClient();
		try
		{
			var queryString = QueryString.Create(new Dictionary<string, string?> { {"date", date.ToString()} } );	
			
			var response = await client.GetFromJsonAsync<FoodResponse>("api/v1/food-log" + queryString);

			return response.Foods;
		}
		catch (Exception e)
		{
			//TODO Display error
			return [];
		}
	}
	public async Task LogFood(FoodModel foodModel, DateTime date)
	{
		var client = CreateClient();

		var request = new LogFoodRequest(foodModel.FoodId, foodModel.Amount, foodModel.Unit, foodModel.MealType, date);

		var response = await client.PostAsJsonAsync("api/v1/food-entry", request);
		response.EnsureSuccessStatusCode();
	}
	
	private HttpClient CreateClient()
	{
		var client = factory.CreateClient(nameof(FoodListAdapter));

		return client;
	}
}