﻿using System.Text.Json;
using NutritionTrackR.Contracts.Food;
using NutritionTrackR.Contracts.Nutrition.Target;

namespace NutritionTrackR.Web.Services;

public class NutritionTargetAdapter(IHttpClientFactory factory)
{
	public async Task<NutritionTargetDto> GetNutritionTarget()
	{
		var client = CreateClient();

		var response = await client.GetAsync("api/v1/nutrition-target");
		response.EnsureSuccessStatusCode();

		var responseBody = await response.Content.ReadAsStringAsync();
		
		var nutritionTarget = JsonSerializer.Deserialize<NutritionTargetDto>(responseBody);
		
		return nutritionTarget;
	}

	public async Task SetNutritionTarget(List<NutrientDto> nutrients)
	{
		var client = CreateClient();
		var request = new NutritionTargetRequest
		{
			StartDate = DateOnly.FromDateTime(DateTime.Now),
			NutrientGoals = nutrients
		};

		var response = await client.PostAsJsonAsync("api/v1/nutrition-target/set", request);
		response.EnsureSuccessStatusCode();
	}
		
	private HttpClient CreateClient()
	{
		var client = factory.CreateClient(nameof(NutritionTargetAdapter));

		return client;
	}
}