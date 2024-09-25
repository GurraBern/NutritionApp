using Google.Cloud.Firestore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nutrition.Core;

namespace PersonalhealthAPI.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class NutritionController : ControllerBase
{
    private readonly FirestoreDb _db;

    public NutritionController(FirestoreDb db)
    {
        _db = db;
    }

    [HttpGet("day/{userid}/{dateToQuery}")]
    public async Task<ActionResult<NutritionDayV1>> GetNutritionDay(string userId, DateTime dateToQuery)
    {
        try
        {
            string date = dateToQuery.ToString("yyyy-MM-dd");

            var nutritionDaysCollectionRef = _db.Collection("Users").Document(userId).Collection("NutritionDays");

            QuerySnapshot querySnapshot = await nutritionDaysCollectionRef
                .WhereEqualTo("Date", date)
                .GetSnapshotAsync();

            var nutritionDay = querySnapshot.Documents
                .Select(doc => doc.ConvertTo<NutritionDayV1>()).FirstOrDefault() ?? new NutritionDayV1()
                {
                    Date = date
                };

            return Ok(nutritionDay);
        }
        catch (Exception ex)
        {
            //TODO add logging
            throw;
        }
    }

    [HttpPost("day/create/{userid}")]
    public async Task<IActionResult> CreateNutritionDay(string userId, [FromBody] NutritionDayV1 nutritionDayV1)
    {
        try
        {
            if (nutritionDayV1 == null)
                return BadRequest("Invalid data. NutritionDay is required.");

            DocumentReference userDocRef = _db.Collection("Users").Document(userId);

            CollectionReference nutritionDaysCollectionRef = userDocRef.Collection("NutritionDays");

            await nutritionDaysCollectionRef.AddAsync(nutritionDayV1);

            return Ok();

        }
        catch (Exception ex)
        {
            //TODO add logging
            throw;
        }
    }

    [HttpPost("day/save/{userid}")]
    public async Task<IActionResult> SaveNutritionDay(string userId, [FromBody] NutritionDayV1 nutritionDayV1)
    {
        try
        {
            CollectionReference nutritionDaysCollectionRef = _db.Collection("Users").Document(userId).Collection("NutritionDays");

            QuerySnapshot querySnapshot = await nutritionDaysCollectionRef
                .WhereEqualTo("Date", nutritionDayV1.Date)
                .GetSnapshotAsync();

            if (querySnapshot.Documents.Count > 0)
            {
                DocumentReference nutritionDayDocRef = querySnapshot.Documents[0]?.Reference;
                await nutritionDayDocRef.SetAsync(nutritionDayV1);
            }
            else
            {
                await CreateNutritionDay(userId, nutritionDayV1);
            }

            return Ok();
        }
        catch (Exception ex)
        {
            //TODO add logging
            throw;
        }
    }
}