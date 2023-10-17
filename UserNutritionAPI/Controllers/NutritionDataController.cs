using Google.Cloud.Firestore;
using Microsoft.AspNetCore.Mvc;
using Nutrition.Core;

namespace UserNutritionAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NutritionDataController : ControllerBase
    {
        private FirestoreDb db;

        public NutritionDataController()
        {
            db = FirestoreDb.Create("nutritiontracker-f8aba");
        }

        [HttpGet("getnutrition/{userid}/{dateToQuery}")]
        public async Task<NutritionDay> GetNutritionDay(string userId, DateTime dateToQuery)
        {
            try
            {
                string date = dateToQuery.ToString("yyyy-MM-dd");

                var nutritionDaysCollectionRef = db.Collection("Users").Document(userId).Collection("NutritionDays");

                QuerySnapshot querySnapshot = await nutritionDaysCollectionRef
                    .WhereEqualTo("Date", date)
                    .GetSnapshotAsync();

                var nutritionDay = querySnapshot.Documents
                    .Select(doc => doc.ConvertTo<NutritionDay>()).FirstOrDefault() ?? new NutritionDay()
                    {
                        Date = date
                    };

                return nutritionDay;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost("insertnutrition/{userid}/{nutritionDay}")]
        public async Task InsertNutritionDay(string userId, NutritionDay nutritionDay)
        {
            try
            {
                DocumentReference userDocRef = db.Collection("Users").Document(userId);

                CollectionReference nutritionDaysCollectionRef = userDocRef.Collection("NutritionDays");

                await nutritionDaysCollectionRef.AddAsync(nutritionDay);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPatch("updatenutrition/{userid}/{nutritionDay}")]
        public async Task UpdateNutritionDay(string userId, NutritionDay nutritionDay)
        {
            try
            {
                CollectionReference nutritionDaysCollectionRef = db.Collection("Users").Document(userId).Collection("NutritionDays");

                QuerySnapshot querySnapshot = await nutritionDaysCollectionRef
                    .WhereEqualTo("Date", nutritionDay.Date)
                    .GetSnapshotAsync();

                if (querySnapshot.Documents.Count > 0)
                {
                    DocumentReference nutritionDayDocRef = querySnapshot.Documents[0]?.Reference;
                    await nutritionDayDocRef.SetAsync(nutritionDay);
                }
                else
                {
                    await InsertNutritionDay(userId, nutritionDay);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
