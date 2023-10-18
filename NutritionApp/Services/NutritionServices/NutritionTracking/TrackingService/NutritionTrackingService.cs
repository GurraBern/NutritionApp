using Nutrition.Core;
using RestSharp;

namespace NutritionApp.Services.NutritionServices;

public class NutritionTrackingService : INutritionTrackingService
{
    private readonly NutritionApiClient nutritionApiClient;
    private readonly IAuthService authService;

    public NutritionTrackingService(NutritionApiClient nutritionApiClient, IAuthService authService)
    {
        this.nutritionApiClient = nutritionApiClient;
        this.authService = authService;
    }

    public async Task<NutritionDay> GetNutritionDay(DateTime dateToQuery)
    {
        var request = new RestRequest($"/api/NutritionData/getnutrition/{authService.CurrentUser.Uid}/{dateToQuery}");

        var nutritionDay = await nutritionApiClient.GetAsync<NutritionDay>(request, authService.CurrentUser.Credential.IdToken);

        return nutritionDay;
    }
}
