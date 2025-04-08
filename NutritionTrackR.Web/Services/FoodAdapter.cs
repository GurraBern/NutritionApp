using NutritionTrackR.Contracts.Food;
using NutritionTrackR.Contracts.Nutrition.NutritionTracking;
using NutritionTrackR.Web.Extensions;
using NutritionTrackR.Web.Shared.FoodSearch.AddFood;

namespace NutritionTrackR.Web.Services;

public class FoodAdapter(IHttpClientFactory factory)
{
	public async Task CreateFood(string foodName, List<NutrientDto> nutrients, CancellationToken token = default)
	{
		var client = CreateClient();

		var request = new CreateFoodRequest
		{
			Name = foodName,
			Nutrients = nutrients
		};

		var response = await client.PostAsJsonAsync("api/v1/foods", request, cancellationToken: token);
		// response.EnsureSuccessStatusCode();
	}
	
	private HttpClient CreateClient()
	{
		var client = factory.CreateClient(nameof(FoodListAdapter));

		return client;
	}
}