using Google.Cloud.Firestore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nutrition.Core;

namespace UserNutritionAPI.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class MeasurementsController : ControllerBase
{
    private readonly FirestoreDb _db;

    public MeasurementsController(FirestoreDb db)
    {
        _db = db;
    }

    [HttpPost("{userid}")]
    public async Task<IActionResult> CreateMeasurements(string userid, [FromBody] BodyMeasurements bodyMeasurements)
    {
        if (bodyMeasurements == null)
            return BadRequest("Invalid data. BodyMeasurements is required.");

        DocumentReference userDocRef = _db.Collection("Users").Document(userid);

        CollectionReference bodyMeasurementsCollectionRef = userDocRef.Collection("BodyMeasurements");

        await bodyMeasurementsCollectionRef.AddAsync(bodyMeasurements);

        return Ok();
    }
}