using NutritionTrackR.Contracts.Food;
using NutritionTrackR.Contracts.Nutrition.Goals;
using NutritionTrackR.Contracts.Nutrition.Target;

namespace NutritionTrackR.Web.Components.Services;

public class NutritionGoalAdapter
{
	private readonly IHttpClientFactory _factory;

	public NutritionGoalAdapter(IHttpClientFactory factory)
	{
		_factory = factory;
	}

	public async Task SetNutritionGoal(List<NutrientDto> nutrients)
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
		var client = _factory.CreateClient(nameof(NutritionGoalAdapter));

		return client;
	}
}