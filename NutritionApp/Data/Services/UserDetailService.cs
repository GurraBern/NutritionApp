using Nutrition.Core;
using NutritionApp.Components;
using NutritionApp.Data.Services;
using NutritionApp.Data.Services.ApiClients;
using RestSharp;

namespace NutritionApp.Services
{
    public class UserDetailService(IUserMeasurementsApiClient apiClient, IAuthService authService) : BaseService(authService), IUserDetailService
    {
        private readonly IUserMeasurementsApiClient apiClient = apiClient;

        public async Task AddNewWeight(double weight)
        {
            var measurements = new BodyMeasurements()
            {
                Weight = weight
            };

            var request = new RestRequest($"api/Measurements/{UserId}");
            request.AddJsonBody(measurements);

            await apiClient.PostAsync(request, IdToken);
        }

        public BodyMeasurements GetBodyMeasurements()
        {
            //TODO fetch from database
            return new BodyMeasurements()
            {
                Height = 1.75,
                Weight = 75
            };
        }

        public TargetMeasurements GetTargetMeasurements()
        {
            //TODO fetch from database
            return new TargetMeasurements()
            {
                StartingWeight = 76,
                TargetWeight = 70,
                TargetCreationDate = DateTime.Now,
                TargetEndDate = DateTime.Now.AddMonths(7),
            };
        }
    }
}