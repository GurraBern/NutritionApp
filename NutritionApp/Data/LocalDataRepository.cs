using AutoMapper;
using Nutrition.Core;
using SQLite;

namespace NutritionApp.Data;

public class LocalDataRepository : IDataRepository
{
    private readonly SQLiteConnection db;
    private readonly IMapper mapper;

    public LocalDataRepository(IMapper mapper)
    {
        var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "NutritionApp.db");

        db = new SQLiteConnection(databasePath);
        db.CreateTable<FoodItem>();
        db.CreateTable<SearchFoodItem>();
        this.mapper = mapper;
    }

    public IEnumerable<FoodItem> GetRecentFoodItems()
    {
        var searchFoodItems = db.Query<SearchFoodItem>("SELECT * FROM search_history ORDER BY search_time DESC LIMIT 10");

        var foodItems = mapper.Map<IEnumerable<FoodItem>>(searchFoodItems);

        return foodItems;
    }

    public void AddToSearchHistory(FoodItem foodItem)
    {
        var searchFoodItem = mapper.Map<SearchFoodItem>(foodItem);

        db.Insert(searchFoodItem);
    }
}

public interface IDataRepository
{
    IEnumerable<FoodItem> GetRecentFoodItems();

    void AddToSearchHistory(FoodItem foodItem);
}