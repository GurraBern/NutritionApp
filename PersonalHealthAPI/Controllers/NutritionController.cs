using Google.Cloud.Firestore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nutrition.Core;

namespace UserNutritionAPI.Controllers;

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
    public async Task<ActionResult<NutritionDay>> GetNutritionDay(string userId, DateTime dateToQuery)
    {
        try
        {
            string date = dateToQuery.ToString("yyyy-MM-dd");

            var nutritionDaysCollectionRef = _db.Collection("Users").Document(userId).Collection("NutritionDays");

            QuerySnapshot querySnapshot = await nutritionDaysCollectionRef
                .WhereEqualTo("Date", date)
                .GetSnapshotAsync();

            var nutritionDay = querySnapshot.Documents
                .Select(doc => doc.ConvertTo<NutritionDay>()).FirstOrDefault() ?? new NutritionDay()
                {
                    Date = date
                };

            return Ok(nutritionDay);
        }
        catch (Exception ex)
        {
            throw;
        }
    }

    [HttpPost("day/create/{userid}")]
    public async Task<IActionResult> CreateNutritionDay(string userId, [FromBody] NutritionDay nutritionDay)
    {
        if (nutritionDay == null)
            return BadRequest("Invalid data. NutritionDay is required.");

        DocumentReference userDocRef = _db.Collection("Users").Document(userId);

        CollectionReference nutritionDaysCollectionRef = userDocRef.Collection("NutritionDays");

        await nutritionDaysCollectionRef.AddAsync(nutritionDay);

        return Ok();
    }

    [HttpPost("day/save/{userid}")]
    public async Task<IActionResult> SaveNutritionDay(string userId, [FromBody] NutritionDay nutritionDay)
    {
        CollectionReference nutritionDaysCollectionRef = _db.Collection("Users").Document(userId).Collection("NutritionDays");

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
            await CreateNutritionDay(userId, nutritionDay);
        }

        return Ok();
    }
}