using NutritionApp.Components;
using NutritionApp.MVVM.Models;

namespace NutritionApp.Services
{
    public class UserDetailService : IUserDetailService
    {
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
                TargetCreated = DateTime.Now
            };
        }
    }
}