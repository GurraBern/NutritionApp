using NutritionApp.Components;
using NutritionApp.MVVM.Models;

namespace NutritionApp.Services
{
    public interface IUserDetailService
    {
        public BodyMeasurements GetBodyMeasurements();

        public TargetMeasurements GetTargetMeasurements();
    }
}