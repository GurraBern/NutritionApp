using Nutrition.Core;
using NutritionApp.Components;

namespace NutritionApp.Services
{
    public interface IUserDetailService
    {
        public BodyMeasurements GetBodyMeasurements();

        public TargetMeasurements GetTargetMeasurements();

        public Task AddNewWeight(double weight);
    }
}