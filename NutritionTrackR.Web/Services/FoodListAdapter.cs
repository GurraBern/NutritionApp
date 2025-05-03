using System.Globalization;
using System.Text.Json;
using NutritionTrackR.Contracts;
using NutritionTrackR.Contracts.Food;
using NutritionTrackR.Contracts.Nutrition.NutritionTracking;
using NutritionTrackR.Web.Extensions;
using NutritionTrackR.Web.Shared.FoodSearch.AddFood;

namespace NutritionTrackR.Web.Services;

public class FoodListAdapter(IHttpClientFactory factory)
{
	public async Task<IEnumerable<FoodDto>> GetFoodItems(string searchTerm = "", CancellationToken token = default)
	{
		var client = CreateClient();
		
		var queryString = QueryString.Create(new Dictionary<string, string?> { {"searchTerm", searchTerm} } );	
		
		var response = await client.GetAsync("api/v1/foods" + queryString, token);
		if (!response.IsSuccessStatusCode) //TODO show popup
			return [];

		var responseBody = await response.Content.ReadAsStringAsync(token);

		var foodResponse = JsonSerializer.Deserialize<FoodResponse>(responseBody);

		return foodResponse?.Foods ?? [];
	}

	public async Task<List<LoggedFoodModel>> GetLoggedFood(DateOnly date, CancellationToken cancellationToken = default)
	{
		var client = CreateClient();
		try
		{
			var queryString = QueryString.Create(new Dictionary<string, string?> { {"date", date.ToString(CultureInfo.InvariantCulture)} } );	
			
			var response = await client.GetFromJsonAsync<LoggedFoodResponse>("api/v1/food-logs" + queryString, cancellationToken);

			var loggedFood = response.Foods.Select(foodDto => new LoggedFoodModel(foodDto, foodDto.LoggedFoodId)).ToList();

			return loggedFood;
		}
		catch (Exception e)
		{
			//TODO Display error
			return [];
		}
	}
	
	public async Task LogFood(FoodModel foodModel, DateOnly date)
	{
		var client = CreateClient();

		var request = new LogFoodRequest(foodModel.FoodId, (decimal)foodModel.Amount, foodModel.Unit.ToString(), foodModel.MealType, date.ToDateTime());

		var response = await client.PostAsJsonAsync("api/v1/food-logs", request);
		response.EnsureSuccessStatusCode();
	}
	
		public async Task<ApiResponse> UpdateLoggedFood(LoggedFoodModel foodModel, DateOnly date)
	{
		var client = CreateClient();

		var request = new UpdateLoggedFoodRequest
		{
			Date = date.ToDateTime(),
			FoodId = foodModel.FoodId,
			LoggedFoodId = foodModel.LoggedFoodId!.Value,
			Weight = (decimal)foodModel.Amount,
			Unit = foodModel.Unit.ToString(),
			MealType = foodModel.MealType
		};

		var updateResponse = await client.PutAsJsonAsync("api/v1/food-logs", request);
		if(updateResponse.IsSuccessStatusCode is false)
			return await updateResponse.Content.ReadFromJsonAsync<ApiResponse>() ?? ApiResponse.DefaultError();
		
		return ApiResponse.Success();
	}
		
	public async Task<ApiResponse> RemoveLoggedFood(LoggedFoodModel foodModel, DateOnly date)
	{
		var client = CreateClient();

		var request = new DeleteLoggedFoodRequest
		{
			Date = date.ToDateTime(),
			LoggedFoodId = foodModel.LoggedFoodId!.Value
		};

		var deleteResponse = await client.PostAsJsonAsync("api/v1/food-logs/delete", request);
		
		if(deleteResponse.IsSuccessStatusCode)
			return ApiResponse.Success();
			
		return await deleteResponse.Content.ReadFromJsonAsync<ApiResponse>() ?? ApiResponse.DefaultError();
	}
	
	private HttpClient CreateClient()
	{
		var client = factory.CreateClient(nameof(FoodListAdapter));

		return client;
	}
}