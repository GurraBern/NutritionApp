using Nutrition.Core;
using NutritionApp.Components;
using NutritionApp.Services;
using RestSharp;

namespace NutritionApp.Data.Services
{
    public class MeasurementsService(IPersonalHealthApiClient<BodyMeasurement> apiClient, IAuthService authService) : BaseService(authService), IMeasurementsService
    {
        private readonly IPersonalHealthApiClient<BodyMeasurement> _apiClient = apiClient;

        public async Task AddNewWeight(double weight)
        {
            var measurements = new BodyMeasurement()
            {
                Weight = weight
            };

            var request = new RestRequest($"api/Measurements/{UserId}");
            request.AddJsonBody(measurements);

            await _apiClient.PostAsync(request, IdToken);
        }

        public async Task<IEnumerable<BodyMeasurement>> GetBodyMeasurements()
        {
            var request = new RestRequest($"api/Measurements/{UserId}");

            var bodyMeasurements = await _apiClient.GetListAsync(request, IdToken);

            return bodyMeasurements;
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