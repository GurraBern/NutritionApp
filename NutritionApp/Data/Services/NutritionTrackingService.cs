using Nutrition.Core;
using NutritionApp.Services;
using RestSharp;

namespace NutritionApp.Data.Services;

public class NutritionTrackingService(IPersonalHealthApiClient<NutritionDay> nutritionApiClient, IAuthService authService) : BaseService(authService), INutritionTrackingService
{
    private readonly IPersonalHealthApiClient<NutritionDay> nutritionApiClient = nutritionApiClient;

    public async Task<NutritionDay> GetNutritionDay(DateTime dateToQuery)
    {
        var request = new RestRequest($"api/Nutrition/day/{UserId}/{dateToQuery}");
        var nutritionDay = await nutritionApiClient.GetAsync(request, IdToken);

        return nutritionDay;
    }

    public async Task SaveNutritionDay(NutritionDay nutritionDay)
    {
        var request = new RestRequest($"api/Nutrition/day/save/{UserId}");
        request.AddJsonBody(nutritionDay);

        await nutritionApiClient.PostAsync(request, IdToken);
    }
}