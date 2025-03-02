using System.Globalization;
using FluentResults;
using NutritionTrackR.Core.Foods;
using NutritionTrackR.Core.Foods.ValueObjects;
using NutritionTrackR.Core.Shared.ValueObjects;

namespace NutritionTrackR.Infrastructure.External;

public class FoodCsvParser
{
    public static List<Food> ParseCsvFile(string filePath)
    {
        List<Food> foods = [];

        try
        {
            using var reader = new StreamReader(filePath);
            
            reader.ReadLine();
                
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();

                var fields = ParseCsvLine(line);

                var nutrients = new List<Nutrient>();
                CreateNutrientGreaterThanZero(Nutrient.Create("Calories", Weight.Create(double.Parse(fields[4], CultureInfo.InvariantCulture), WeightUnit.Kcal).Value), nutrients);
                CreateNutrientGreaterThanZero(Nutrient.Create("Protein", Weight.Create(double.Parse(fields[5], CultureInfo.InvariantCulture), WeightUnit.Grams).Value), nutrients);
                CreateNutrientGreaterThanZero(Nutrient.Create("Carbohydrates", Weight.Create(double.Parse(fields[6], CultureInfo.InvariantCulture), WeightUnit.Grams).Value), nutrients);
                CreateNutrientGreaterThanZero(Nutrient.Create("Sugars Total", Weight.Create(double.Parse(fields[7], CultureInfo.InvariantCulture), WeightUnit.Grams).Value), nutrients);
                CreateNutrientGreaterThanZero(Nutrient.Create("Fiber Total", Weight.Create(double.Parse(fields[8], CultureInfo.InvariantCulture), WeightUnit.Grams).Value), nutrients);
                CreateNutrientGreaterThanZero(Nutrient.Create("Total Fat", Weight.Create(double.Parse(fields[9], CultureInfo.InvariantCulture), WeightUnit.Grams).Value), nutrients);
                CreateNutrientGreaterThanZero(Nutrient.Create("Saturated Fatty Acids Total", Weight.Create(double.Parse(fields[10], CultureInfo.InvariantCulture), WeightUnit.Grams).Value), nutrients);
                CreateNutrientGreaterThanZero(Nutrient.Create("Fatty Acids Total Monounsaturated", Weight.Create(double.Parse(fields[11], CultureInfo.InvariantCulture), WeightUnit.Grams).Value), nutrients);
                CreateNutrientGreaterThanZero(Nutrient.Create("Fatty Acids Total Polyunsaturated", Weight.Create(double.Parse(fields[12], CultureInfo.InvariantCulture), WeightUnit.Grams).Value), nutrients);
                CreateNutrientGreaterThanZero(Nutrient.Create("Cholesterol", Weight.Create(double.Parse(fields[13], CultureInfo.InvariantCulture), WeightUnit.Milligram).Value), nutrients);
                CreateNutrientGreaterThanZero(Nutrient.Create("Retinol", Weight.Create(double.Parse(fields[14], CultureInfo.InvariantCulture), WeightUnit.Microgram).Value), nutrients);
                CreateNutrientGreaterThanZero(Nutrient.Create("Vitamin A RAE", Weight.Create(double.Parse(fields[15], CultureInfo.InvariantCulture), WeightUnit.Microgram).Value), nutrients);
                CreateNutrientGreaterThanZero(Nutrient.Create("Carotene Alpha", Weight.Create(double.Parse(fields[16], CultureInfo.InvariantCulture), WeightUnit.Microgram).Value), nutrients);
                CreateNutrientGreaterThanZero(Nutrient.Create("Carotene Beta", Weight.Create(double.Parse(fields[17], CultureInfo.InvariantCulture), WeightUnit.Microgram).Value), nutrients);
                CreateNutrientGreaterThanZero(Nutrient.Create("Cryptoxanthin Beta", Weight.Create(double.Parse(fields[18], CultureInfo.InvariantCulture), WeightUnit.Microgram).Value), nutrients);
                CreateNutrientGreaterThanZero(Nutrient.Create("Lycopene", Weight.Create(double.Parse(fields[19], CultureInfo.InvariantCulture), WeightUnit.Microgram).Value), nutrients);
                CreateNutrientGreaterThanZero(Nutrient.Create("Lutein Zeaxanthin", Weight.Create(double.Parse(fields[20], CultureInfo.InvariantCulture), WeightUnit.Microgram).Value), nutrients);
                CreateNutrientGreaterThanZero(Nutrient.Create("Thiamin", Weight.Create(double.Parse(fields[21], CultureInfo.InvariantCulture), WeightUnit.Microgram).Value), nutrients);
                CreateNutrientGreaterThanZero(Nutrient.Create("Riboflavin", Weight.Create(double.Parse(fields[22], CultureInfo.InvariantCulture), WeightUnit.Microgram).Value), nutrients);
                CreateNutrientGreaterThanZero(Nutrient.Create("Vitamin B6", Weight.Create(double.Parse(fields[23], CultureInfo.InvariantCulture), WeightUnit.Microgram).Value), nutrients);
                CreateNutrientGreaterThanZero(Nutrient.Create("Folic Acid", Weight.Create(double.Parse(fields[24], CultureInfo.InvariantCulture), WeightUnit.Microgram).Value), nutrients);
                CreateNutrientGreaterThanZero(Nutrient.Create("Folate DFE", Weight.Create(double.Parse(fields[25], CultureInfo.InvariantCulture), WeightUnit.Microgram).Value), nutrients);
                CreateNutrientGreaterThanZero(Nutrient.Create("Folate Total", Weight.Create(double.Parse(fields[26], CultureInfo.InvariantCulture), WeightUnit.Microgram).Value), nutrients);
                CreateNutrientGreaterThanZero(Nutrient.Create("Choline Total", Weight.Create(double.Parse(fields[27], CultureInfo.InvariantCulture), WeightUnit.Microgram).Value), nutrients);
                CreateNutrientGreaterThanZero(Nutrient.Create("Vitamin B12", Weight.Create(double.Parse(fields[28], CultureInfo.InvariantCulture), WeightUnit.Microgram).Value), nutrients);
                CreateNutrientGreaterThanZero(Nutrient.Create("Vitamin B12 Added", Weight.Create(double.Parse(fields[29], CultureInfo.InvariantCulture), WeightUnit.Microgram).Value), nutrients);
                CreateNutrientGreaterThanZero(Nutrient.Create("Vitamin C", Weight.Create(double.Parse(fields[30], CultureInfo.InvariantCulture), WeightUnit.Microgram).Value), nutrients);
                CreateNutrientGreaterThanZero(Nutrient.Create("Vitamin D", Weight.Create(double.Parse(fields[31], CultureInfo.InvariantCulture), WeightUnit.Microgram).Value), nutrients);
                CreateNutrientGreaterThanZero(Nutrient.Create("Vitamin E Alpha Tocopherol", Weight.Create(double.Parse(fields[32], CultureInfo.InvariantCulture), WeightUnit.Microgram).Value), nutrients);
                CreateNutrientGreaterThanZero(Nutrient.Create("Vitamin E Added", Weight.Create(double.Parse(fields[33], CultureInfo.InvariantCulture), WeightUnit.Microgram).Value), nutrients);
                CreateNutrientGreaterThanZero(Nutrient.Create("Vitamin K Phylloquinone", Weight.Create(double.Parse(fields[34], CultureInfo.InvariantCulture), WeightUnit.Microgram).Value), nutrients);
                CreateNutrientGreaterThanZero(Nutrient.Create("Calcium", Weight.Create(double.Parse(fields[35], CultureInfo.InvariantCulture), WeightUnit.Milligram).Value), nutrients);
                CreateNutrientGreaterThanZero(Nutrient.Create("Phosphorus", Weight.Create(double.Parse(fields[36], CultureInfo.InvariantCulture), WeightUnit.Milligram).Value), nutrients);
                CreateNutrientGreaterThanZero(Nutrient.Create("Magnesium", Weight.Create(double.Parse(fields[37], CultureInfo.InvariantCulture), WeightUnit.Milligram).Value), nutrients);
                CreateNutrientGreaterThanZero(Nutrient.Create("Iron", Weight.Create(double.Parse(fields[38], CultureInfo.InvariantCulture), WeightUnit.Milligram).Value), nutrients);
                CreateNutrientGreaterThanZero(Nutrient.Create("Zinc", Weight.Create(double.Parse(fields[39], CultureInfo.InvariantCulture), WeightUnit.Milligram).Value), nutrients);
                CreateNutrientGreaterThanZero(Nutrient.Create("Selenium", Weight.Create(double.Parse(fields[40], CultureInfo.InvariantCulture), WeightUnit.Microgram).Value), nutrients);
                CreateNutrientGreaterThanZero(Nutrient.Create("Potassium", Weight.Create(double.Parse(fields[41], CultureInfo.InvariantCulture), WeightUnit.Milligram).Value), nutrients);
                CreateNutrientGreaterThanZero(Nutrient.Create("Sodium", Weight.Create(double.Parse(fields[42], CultureInfo.InvariantCulture), WeightUnit.Milligram).Value), nutrients);
                CreateNutrientGreaterThanZero(Nutrient.Create("Caffeine", Weight.Create(double.Parse(fields[43], CultureInfo.InvariantCulture), WeightUnit.Milligram).Value), nutrients);
                CreateNutrientGreaterThanZero(Nutrient.Create("Theobromine", Weight.Create(double.Parse(fields[44], CultureInfo.InvariantCulture), WeightUnit.Milligram).Value), nutrients);
                CreateNutrientGreaterThanZero(Nutrient.Create("Alcohol", Weight.Create(double.Parse(fields[45], CultureInfo.InvariantCulture), WeightUnit.Grams).Value), nutrients);
                CreateNutrientGreaterThanZero(Nutrient.Create("Water", Weight.Create(double.Parse(fields[68], CultureInfo.InvariantCulture), WeightUnit.Grams).Value), nutrients);

                //Add external id if needed
                foods.Add(Food.Create(fields[1], nutrients).Value);
            }
            
            return foods;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error parsing CSV: {ex.Message}");
        }

        return [];
    }
    private static void CreateNutrientGreaterThanZero(Result<Nutrient> calories, List<Nutrient> nutrients)
    {
        if(calories is { IsSuccess: true, Value.Weight.Value: > 0 })
            nutrients.Add(calories.Value);
    }

    static string[] ParseCsvLine(string line)
    {
        List<string> fields = [];
        bool inQuotes = false;
        string currentField = "";

        foreach (var c in line)
        {
            if (c == '"' && inQuotes)
            {
                inQuotes = false;
            }
            else if (c == '"' && !inQuotes)
            {
                inQuotes = true;
            }
            else if (c == ',' && !inQuotes)
            {
                fields.Add(currentField);
                currentField = "";
            }
            else
            {
                currentField += c;
            }
        }

        fields.Add(currentField);

        return fields.ToArray();
    }
}

public class ExternalFood
{
    public string FoodCode { get; set; }
    public string MainFoodDescription { get; set; }
    public int WWEIACategoryNumber { get; set; }
    public string WWEIACategoryDescription { get; set; }
    public double EnergyKcal { get; set; }
    public double Protein { get; set; }
    public double Carbohydrate { get; set; }
    public double SugarsTotal { get; set; }
    public double FiberTotalDietary { get; set; }
    public double TotalFat { get; set; }
    public double FattyAcidsTotalSaturated { get; set; }
    public double FattyAcidsTotalMonounsaturated { get; set; }
    public double FattyAcidsTotalPolyunsaturated { get; set; }
    public double Cholesterol { get; set; }
    public double Retinol { get; set; }
    public double VitaminARAE { get; set; }
    public double CaroteneAlpha { get; set; }
    public double CaroteneBeta { get; set; }
    public double CryptoxanthinBeta { get; set; }
    public double Lycopene { get; set; }
    public double LuteinZeaxanthin { get; set; }
    public double Thiamin { get; set; }
    public double Riboflavin { get; set; }
    public double Niacin { get; set; }
    public double VitaminB6 { get; set; }
    public double FolicAcid { get; set; }
    public double FolateFood { get; set; }
    public double FolateDFE { get; set; }
    public double FolateTotal { get; set; }
    public double CholineTotal { get; set; }
    public double VitaminB12 { get; set; }
    public double VitaminB12Added { get; set; }
    public double VitaminC { get; set; }
    public double VitaminD { get; set; }
    public double VitaminEAlphaTocopherol { get; set; }
    public double VitaminEAdded { get; set; }
    public double VitaminKPhylloquinone { get; set; }
    public double Calcium { get; set; }
    public double Phosphorus { get; set; }
    public double Magnesium { get; set; }
    public double Iron { get; set; }
    public double Zinc { get; set; }
    public double Copper { get; set; }
    public double Selenium { get; set; }
    public double Potassium { get; set; }
    public double Sodium { get; set; }
    public double Caffeine { get; set; }
    public double Theobromine { get; set; }
    public double Alcohol { get; set; }
    public double FourCarbonAcids { get; set; }
    public double SixCarbonAcids { get; set; }
    public double EightCarbonAcids { get; set; }
    public double TenCarbonAcids { get; set; }
    public double TwelveCarbonAcids { get; set; }
    public double FourteenCarbonAcids { get; set; }
    public double SixteenCarbonAcids { get; set; }
    public double EighteenCarbonAcids { get; set; }
    public double SixteenOneAcids { get; set; }
    public double EighteenOneAcids { get; set; }
    public double TwentyOneAcids { get; set; }
    public double TwentyTwoOneAcids { get; set; }
    public double EighteenTwoAcids { get; set; }
    public double EighteenThreeAcids { get; set; }
    public double EighteenFourAcids { get; set; }
    public double TwentyFourAcids { get; set; }
    public double TwentyFiveThreeAcids { get; set; }
    public double TwentyTwoFiveThreeAcids { get; set; }
    public double TwentySixThreeAcids { get; set; }
    public double Water { get; set; }
}