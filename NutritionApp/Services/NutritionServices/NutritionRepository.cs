using Google.Cloud.Firestore;
using NutritionApp.MVVM.Models;

namespace NutritionApp.Services.NutritionServices;

public class NutritionRepository : INutritionRepository
{
    private readonly FirestoreDb db;

    public NutritionRepository()
    {
        var path = AppDomain.CurrentDomain.BaseDirectory + @"nutritiontracker-f8aba-firebase-adminsdk-5c3g1-0ea3e21e69.json";
        Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", path);

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

            DocumentReference nutritionDayDocRef = querySnapshot.Documents[0]?.Reference;

            await nutritionDayDocRef.SetAsync(updatedNutritionDay);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}
