﻿using System.Globalization;
using NutritionTrackR.Contracts.Food;
using System.Text.Json;
using NutritionTrackR.Contracts;
using NutritionTrackR.Contracts.Nutrition.NutritionTracking;
using NutritionTrackR.Web.Components.Pages.NutritionDay;
using NutritionTrackR.Web.Extensions;
using NutritionTrackR.Web.Shared.FoodSearch.AddFood;

namespace NutritionTrackR.Web.Components.Services;

public class FoodListAdapter(IHttpClientFactory factory)
{
	public async Task<IEnumerable<FoodDto>> GetFoodItems(string searchTerm = "", CancellationToken token = default)
	{
		var client = CreateClient();
		
		var queryString = QueryString.Create(new Dictionary<string, string?> { {"searchTerm", searchTerm} } );	
		
		var response = await client.GetAsync("api/v1/food" + queryString, token);
		if (!response.IsSuccessStatusCode) //TODO show popup
			return [];

		var responseBody = await response.Content.ReadAsStringAsync(token);

		var foodResponse = JsonSerializer.Deserialize<FoodResponse>(responseBody);

		return foodResponse?.Foods ?? [];
	}

	public async Task<List<FoodModel>> GetLoggedFood(DateOnly date)
	{
		var client = CreateClient();
		try
		{
			var queryString = QueryString.Create(new Dictionary<string, string?> { {"date", date.ToString(CultureInfo.InvariantCulture)} } );	
			
			var response = await client.GetFromJsonAsync<LoggedFoodResponse>("api/v1/food-log" + queryString);

			var loggedFood = response.Foods.Select(foodDto => new FoodModel(foodDto, foodDto.LoggedFoodId)).ToList();

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

		var request = new LogFoodRequest(foodModel.FoodId, foodModel.Amount, foodModel.Unit, foodModel.MealType, date.ToDateTime());

		var response = await client.PostAsJsonAsync("api/v1/food-entry", request);
		response.EnsureSuccessStatusCode();
	}
	
		public async Task<ApiResponse> UpdateLoggedFood(FoodModel foodModel, DateOnly date)
	{
		var client = CreateClient();

		var request = new UpdateLoggedFoodRequest
		{
			Date = date.ToDateTime(),
			FoodId = foodModel.FoodId,
			LoggedFoodId = foodModel.LoggedFoodId!.Value,
			Weight = foodModel.Amount,
			Unit = foodModel.Unit,
			MealType = foodModel.MealType
		};

		var updateResponse = await client.PutAsJsonAsync("api/v1/food-entry", request);
		if(updateResponse.IsSuccessStatusCode is false)
			return await updateResponse.Content.ReadFromJsonAsync<ApiResponse>() ?? ApiResponse.DefaultError();
		
		return ApiResponse.Success();
	}
		
	public async Task<ApiResponse> RemoveLoggedFood(FoodModel foodModel, DateOnly date)
	{
		var client = CreateClient();

		var request = new DeleteLoggedFoodRequest
		{
			Date = date.ToDateTime(),
			LoggedFoodId = foodModel.LoggedFoodId!.Value
		};

		var deleteResponse = await client.PostAsJsonAsync("api/v1/food-entry/delete", request);
		
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