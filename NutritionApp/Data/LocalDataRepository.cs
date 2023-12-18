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
        this.mapper = mapper;

        var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "NutritionApp.db3");

        db = new SQLiteConnection(databasePath);
        db.CreateTable<FoodItem>();
        db.CreateTable<SearchFoodItem>();
    }

    public IEnumerable<FoodItem> GetRecentFoodItems()
    {
        var searchFoodItems = db.Query<SearchFoodItem>("SELECT * FROM search_history GROUP BY Id ORDER BY search_time DESC LIMIT 10");

        var foodItems = mapper.Map<IEnumerable<FoodItem>>(searchFoodItems);

        return foodItems;
    }

    public void AddToSearchHistory(FoodItem foodItem)
    {
        var searchFoodItem = mapper.Map<SearchFoodItem>(foodItem);

        db.Insert(searchFoodItem);
    }

    public IEnumerable<FoodItem> SearchRecentFoodItems(string query)
    {
        var searchFoodItems = db.Query<SearchFoodItem>("SELECT * FROM search_history WHERE Name LIKE ? GROUP BY Id ORDER BY search_time DESC LIMIT 10", "%" + query + "%");

        var foodItems = mapper.Map<IEnumerable<FoodItem>>(searchFoodItems);

        return foodItems;
    }
}

public interface IDataRepository
{
    IEnumerable<FoodItem> GetRecentFoodItems();

    IEnumerable<FoodItem> SearchRecentFoodItems(string query);

    void AddToSearchHistory(FoodItem foodItem);
}