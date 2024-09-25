using Nutrition.Core;
using NutritionApp.Services;
using RestSharp;

namespace NutritionApp.Data.Services;

public class NutritionTrackingService(IPersonalHealthApiClient<NutritionDayV1> nutritionApiClient, IAuthService authService) : BaseService(authService), INutritionTrackingService
{
    private readonly IPersonalHealthApiClient<NutritionDayV1> nutritionApiClient = nutritionApiClient;

    public async Task<NutritionDayV1> GetNutritionDay(DateTime dateToQuery)
    {
        var request = new RestRequest($"api/Nutrition/day/{UserId}/{dateToQuery}");
        var nutritionDay = await nutritionApiClient.GetAsync(request, IdToken);

        return nutritionDay;
    }

    public async Task SaveNutritionDay(NutritionDayV1 nutritionDayV1)
    {
        var request = new RestRequest($"api/Nutrition/day/save/{UserId}");
        request.AddJsonBody(nutritionDayV1);

        await nutritionApiClient.PostAsync(request, IdToken);
    }
}