using Nutrition.Core;
using NutritionApp.Components;
using NutritionApp.Services;
using RestSharp;

namespace NutritionApp.Data.Services
{
    public class MeasurementsService(IPersonalHealthApiClient<BodyMeasurements> apiClient, IAuthService authService) : BaseService(authService), IMeasurementsService
    {
        private readonly IPersonalHealthApiClient<BodyMeasurements> _apiClient = apiClient;

        public async Task AddNewWeight(double weight)
        {
            var measurements = new BodyMeasurements()
            {
                Weight = weight
            };

            var request = new RestRequest($"api/Measurements/{UserId}");
            request.AddJsonBody(measurements);

            await _apiClient.PostAsync(request, IdToken);
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