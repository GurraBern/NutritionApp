//using Google.Cloud.Firestore;
//using NutritionApp.MVVM.Models;
//using NutritionApp.Services.AuthService;

//namespace NutritionApp.Services.NutritionServices;

//public class NutritionRepository : INutritionRepository
//{
//    private IAuthService authService;
//    private FirestoreDb db;

//    public NutritionRepository(IAuthService authService)
//    {
//        this.authService = authService;
//        //db = FirestoreDb.Create("nutritiontracker-f8aba"); //saknar GOOGLE_APPLICATION_CREDENTIALS
//    }

//    public async Task<NutritionDay> GetNutritionDay(DateTime dateToQuery)
//    {
//        try
//        {
//            string date = dateToQuery.ToString("yyyy-MM-dd");

//            var userId = authService.User.Uid;
//            var nutritionDaysCollectionRef = db.Collection("Users").Document(userId).Collection("NutritionDays");

//            QuerySnapshot querySnapshot = await nutritionDaysCollectionRef
//                .WhereEqualTo("Date", date)
//                .GetSnapshotAsync();

//            var nutritionDay = querySnapshot.Documents
//                .Select(doc => doc.ConvertTo<NutritionDay>()).FirstOrDefault() ?? new NutritionDay()
//                {
//                    Date = date
//                };

//            return nutritionDay;
//        }
//        catch (Exception ex)
//        {
//            throw;
//        }
//    }

//    public async Task InsertNutritionDay(NutritionDay nutritionDay)
//    {
//        try
//        {
//            var userId = authService.User.Uid;
//            DocumentReference userDocRef = db.Collection("Users").Document(userId);

//            CollectionReference nutritionDaysCollectionRef = userDocRef.Collection("NutritionDays");

//            await nutritionDaysCollectionRef.AddAsync(nutritionDay);
//        }
//        catch (Exception ex)
//        {
//            throw ex;
//        }
//    }

//    public async Task UpdateNutritionDay(NutritionDay updatedNutritionDay)
//    {
//        try
//        {
//            var userId = authService.User.Uid;

//            CollectionReference nutritionDaysCollectionRef = db.Collection("Users").Document(userId).Collection("NutritionDays");

//            QuerySnapshot querySnapshot = await nutritionDaysCollectionRef
//                .WhereEqualTo("Date", updatedNutritionDay.Date)
//                .GetSnapshotAsync();

//            if (querySnapshot.Documents.Count > 0)
//            {
//                DocumentReference nutritionDayDocRef = querySnapshot.Documents[0]?.Reference;
//                await nutritionDayDocRef.SetAsync(updatedNutritionDay);
//            }
//            else
//            {
//                await InsertNutritionDay(updatedNutritionDay);
//            }
//        }
//        catch (Exception ex)
//        {
//            throw ex;
//        }
//    }
//}
