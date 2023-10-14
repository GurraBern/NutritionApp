using Google.Cloud.Firestore;
using NutritionApp.MVVM.Models;

namespace NutritionApp.Services.NutritionServices;

public class NutritionRepository : INutritionRepository
{
    private AuthService authService;
    private FirestoreDb db;

    public NutritionRepository(AuthService authService)
    {
        this.authService = authService;
        db = FirestoreDb.Create("nutritiontracker-f8aba");
    }

    public async Task<NutritionDay> GetNutritionDay(DateTime dateToQuery)
    {
        try
        {
            string date = dateToQuery.ToString("yyyy-MM-dd");

            var userId = "2sRR9EhUGTEpHx4XQz6C";
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

    public async Task InsertNutritionDay(NutritionDay nutritionDay)
    {
        try
        {
            var userId = "2sRR9EhUGTEpHx4XQz6C";
            DocumentReference userDocRef = db.Collection("Users").Document(userId);

            CollectionReference nutritionDaysCollectionRef = userDocRef.Collection("NutritionDays");

            await nutritionDaysCollectionRef.AddAsync(nutritionDay);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public async Task UpdateNutritionDay(NutritionDay updatedNutritionDay)
    {
        try
        {
            var userId = "2sRR9EhUGTEpHx4XQz6C";

            CollectionReference nutritionDaysCollectionRef = db.Collection("Users").Document(userId).Collection("NutritionDays");

            QuerySnapshot querySnapshot = await nutritionDaysCollectionRef
                .WhereEqualTo("Date", updatedNutritionDay.Date)
                .GetSnapshotAsync();

            if (querySnapshot.Documents.Count > 0)
            {
                DocumentReference nutritionDayDocRef = querySnapshot.Documents[0]?.Reference;
                await nutritionDayDocRef.SetAsync(updatedNutritionDay);
            }
            else
            {
                await InsertNutritionDay(updatedNutritionDay);
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}
