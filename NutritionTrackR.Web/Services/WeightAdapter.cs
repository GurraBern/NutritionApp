using NutritionTrackR.Contracts.BodyMeasurement;

namespace NutritionTrackR.Web.Services;

public class WeightAdapter(IHttpClientFactory factory)
{
	public async Task<IEnumerable<WeightDto>> GetWeightData()
	{
		var client = CreateClient();

		var weightData = await client.GetFromJsonAsync<BodyWeightDataResponse>("api/v1/body-measurements");

		return weightData?.BodyWeightData ?? [];
	}

	private HttpClient CreateClient()
	{
		//TODO plocka ut user id från header?
		var client = factory.CreateClient(nameof(WeightAdapter));

		return client;
	}
}