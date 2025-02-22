using NutritionTrackR.Contracts.BodyMeasurement;

namespace NutritionTrackR.Web.Services;

public class WeightAdapter(IHttpClientFactory factory)
{
	public async Task<List<WeightDto>> GetWeightData()
	{
		var client = CreateClient();

		var weightData = await client.GetFromJsonAsync<BodyWeightDataResponse>("api/v1/body-measurements");

		return weightData?.BodyWeightData.ToList() ?? [];
	}

	private HttpClient CreateClient()
	{
		//TODO plocka ut user id från header?
		var client = factory.CreateClient(nameof(WeightAdapter));

		return client;
	}
	public async Task TrackWeight(decimal weight)
	{
		var client = CreateClient();

		var request = new TrackBodyWeightRequest()
		{
			UserId = Guid.Empty,
			Weight = (double)weight,
			WeightUnit = "Kilogram"
		};
		
		var response = await client.PostAsJsonAsync("api/v1/body-measurements", request);
		

	}
	public async Task DeleteWeight()
	{
		//TODO if i want it to be a read only database should i still allow deletes? should i instead create a delete weight event
		throw new NotImplementedException();
	}
}