using Google.Cloud.Firestore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nutrition.Core;

namespace UserNutritionAPI.Controllers
{
    [Authorize]
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

        [HttpPost("insertnutrition/{userid}")]
        public async Task<IActionResult> InsertNutritionDay(string userId, [FromBody] NutritionDay nutritionDay)
        {
            if (nutritionDay == null)
                return BadRequest("Invalid data. NutritionDay is required.");

            DocumentReference userDocRef = db.Collection("Users").Document(userId);

            CollectionReference nutritionDaysCollectionRef = userDocRef.Collection("NutritionDays");

            await nutritionDaysCollectionRef.AddAsync(nutritionDay);

            return Ok();
        }

        [HttpPost("SaveNutritionDay/{userid}")]
        public async Task<IActionResult> SaveNutritionDay(string userId, [FromBody] NutritionDay nutritionDay)
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

            return Ok();
        }
    }
}
