using Nutrition.Core;
using RestSharp;

namespace NutritionApp.Services.NutritionServices;

public class UserNutritionTrackingService(IUserNutritionApiClient nutritionApiClient, IAuthService authService) : INutritionTrackingService
{
    public async Task<NutritionDay> GetNutritionDay(DateTime dateToQuery)
    {
        var request = new RestRequest($"/api/NutritionData/getnutrition/{authService.CurrentUser.Uid}/{dateToQuery}");

        var nutritionDay = await nutritionApiClient.GetAsync(request, authService.CurrentUser.Credential.IdToken);

        return nutritionDay;
    }

    public async Task SaveNutritionDay(NutritionDay nutritionDay)
    {
        var request = new RestRequest($"/api/NutritionData/SaveNutritionDay/{authService.CurrentUser.Uid}");
        request.AddJsonBody(nutritionDay);

        await nutritionApiClient.PostAsync(request, authService.CurrentUser.Credential.IdToken);
    }
}