using SQLite;

namespace NutritionApp.Data;

public class LocalDataRepository : IDataRepository
{
    private SQLiteConnection db;

    public LocalDataRepository()
    {
        var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "NutritionApp.db");

        db = new SQLiteConnection(databasePath);
        db.CreateTable<FoodItemDto>();
        db.CreateTable<SearchFoodItem>();
    }

    public void GetRecentFoodItems()
    {
        var query = db.Table<SearchFoodItem>().Where(v => v.Name.StartsWith("t"));
    }

    public void InsertFoodItem(FoodItemDto foodItem)
    {
        db.Insert(foodItem);
    }
}

public interface IDataRepository
{
}