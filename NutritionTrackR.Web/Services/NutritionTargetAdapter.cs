using System.Text.Json;
using FluentResults;
using NutritionTrackR.Contracts.Food;
using NutritionTrackR.Contracts.Nutrition.Target;

namespace NutritionTrackR.Web.Services;

public class NutritionTargetAdapter(IHttpClientFactory factory)
{
	public async Task<NutritionTargetDto> GetNutritionTarget(CancellationToken cancellationToken = default)
	{
		var client = CreateClient();

		var response = await client.GetAsync("api/v1/nutrition-targets", cancellationToken);
		response.EnsureSuccessStatusCode();
		
		var responseBody = await response.Content.ReadAsStringAsync(cancellationToken);
		
		var nutritionTarget = JsonSerializer.Deserialize<NutritionTargetDto>(responseBody);
		
		return nutritionTarget;
	}

	//TODO return result and show snackbar and update view
	public async Task<Result> SetNutritionTarget(List<NutrientDto> nutrients)
	{
		var client = CreateClient();
		var request = new NutritionTargetRequest
		{
			StartDate = DateOnly.FromDateTime(DateTime.Now),
			NutrientGoals = nutrients
		};

		var response = await client.PostAsJsonAsync("api/v1/nutrition-targets/set", request);

		return response.IsSuccessStatusCode ? Result.Ok() : Result.Fail("Could not create nutrition target");
	}
		
	private HttpClient CreateClient()
	{
		var client = factory.CreateClient(nameof(NutritionTargetAdapter));

		return client;
	}
}