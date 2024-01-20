using Nutrition.Core;
using NutritionApp.Data.Services;
using RestSharp;

namespace NutritionApp.Services.NutritionServices;

public class UserNutritionTrackingService(IUserNutritionApiClient nutritionApiClient, IAuthService authService) : BaseService(authService), INutritionTrackingService
{
    private readonly IUserNutritionApiClient nutritionApiClient = nutritionApiClient;

    public async Task<NutritionDay> GetNutritionDay(DateTime dateToQuery)
    {
        var request = new RestRequest($"api/Nutrition/day/{UserId}/{dateToQuery}");

        var nutritionDay = await nutritionApiClient.GetAsync(request, IdToken);

        return nutritionDay;
    }

    public async Task SaveNutritionDay(NutritionDay nutritionDay)
    {
        var request = new RestRequest($"api/Nutrition/day/{UserId}");
        request.AddJsonBody(nutritionDay);

        await nutritionApiClient.PostAsync(request, IdToken);
    }
}