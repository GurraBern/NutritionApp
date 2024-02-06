using Nutrition.Core;
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

        public async Task<BodyMeasurement> GetBodyMeasurement()
        {
            var request = new RestRequest($"api/Measurements/{UserId}/latest");

            var bodyMeasurement = await _apiClient.GetAsync(request, IdToken);

            return bodyMeasurement;
        }

        public TargetMeasurement GetTargetMeasurements()
        {
            //TODO fetch from database
            return new TargetMeasurement()
            {
                StartingWeight = 76,
                TargetWeight = 70,
                TargetCreationDate = DateTime.Now,
                TargetEndDate = DateTime.Now.AddMonths(7),
            };
        }

        public async Task<BodyMeasurement> GetLatestBodyMeasurement()
        {
            var request = new RestRequest($"api/Measurements/{UserId}/latest");

            var bodyMeasurement = await _apiClient.GetAsync(request, IdToken);

            return bodyMeasurement;
        }
    }
}