using Google.Cloud.Firestore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nutrition.Core;

namespace PersonalhealthAPI.Controllers;

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
    public async Task<IActionResult> CreateMeasurements(string userid, [FromBody] BodyMeasurement bodyMeasurements)
    {
        try
        {
            if (bodyMeasurements == null)
                return BadRequest("Invalid data. BodyMeasurements is required.");

            DocumentReference userDocRef = _db.Collection("Users").Document(userid);

            CollectionReference bodyMeasurementsCollectionRef = userDocRef.Collection("BodyMeasurements");

            await bodyMeasurementsCollectionRef.AddAsync(bodyMeasurements);

            var latestBodyMeasurementsCollectionRef = userDocRef.Collection("LatestUserDetails").Document("LatestBodyMeasurements");

            await latestBodyMeasurementsCollectionRef.SetAsync(bodyMeasurements);

            return Ok();
        }
        catch (Exception ex)
        {
            //TODO add logging
            throw;
        }
    }

    [HttpGet("{userid}")]
    public async Task<ActionResult<IEnumerable<BodyMeasurement>>> GetMeasurements(string userid)
    {
        try
        {
            DocumentReference userDocRef = _db.Collection("Users").Document(userid);

            CollectionReference bodyMeasurementsCollectionRef = userDocRef.Collection("BodyMeasurements");

            var querySnapshot = await bodyMeasurementsCollectionRef.GetSnapshotAsync();

            var bodyMeasurements = querySnapshot.Documents
                .Select(x => x.ConvertTo<BodyMeasurement>())
                .ToList();

            return Ok(bodyMeasurements);
        }
        catch (Exception ex)
        {
            //TODO add logging
            throw;
        }
    }

    [HttpGet("{userid}/latest")]
    public async Task<ActionResult<BodyMeasurement>> GetLatestMeasurement(string userid)
    {
        try
        {
            var latestBodyMeasurementsCollectionRef = _db.Collection("Users").Document(userid).Collection("LatestUserDetails");

            QuerySnapshot querySnapshot = await latestBodyMeasurementsCollectionRef.GetSnapshotAsync();

            var bodyMeasurement = querySnapshot.Documents.FirstOrDefault()?.ConvertTo<BodyMeasurement>();

            return Ok(bodyMeasurement);
        }
        catch (Exception ex)
        {
            //TODO add logging
            throw;
        }
    }
}
