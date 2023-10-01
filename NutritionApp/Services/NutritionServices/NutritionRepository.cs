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

    public async Task<IEnumerable<FoodItem>> GetConsumedFood()
    {
        try
        {
            var userId = "2sRR9EhUGTEpHx4XQz6C";
            var consumedFoodCollectionRef = db.Collection("Users").Document(userId).Collection("ConsumedFood");

            QuerySnapshot querySnapshot = await consumedFoodCollectionRef.GetSnapshotAsync();

            var consumedFood = querySnapshot.Documents.Select(doc => doc.ConvertTo<FoodItem>());

            return consumedFood;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public async Task InsertConsumedFood(FoodItem foodItem)
    {
        try
        {
            var userId = "2sRR9EhUGTEpHx4XQz6C";
            DocumentReference userDocRef = db.Collection("Users").Document(userId);

            CollectionReference consumedFoodCollectionRef = userDocRef.Collection("ConsumedFood");

            await consumedFoodCollectionRef.AddAsync(foodItem);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}
