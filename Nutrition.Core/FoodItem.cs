using Google.Cloud.Firestore;

namespace Nutrition.Core;

[FirestoreData]
public class FoodItem
{
    [FirestoreProperty]
    public string Id { get; set; }

    [FirestoreProperty]
    public string Name { get; set; }

    [FirestoreProperty]
    public string Creator { get; set; }

    [FirestoreProperty]
    public int Amount { get; set; } = 100;

    [FirestoreProperty]
    public double Calories { get; set; }

    [FirestoreProperty]
    public double Protein { get; set; }

    [FirestoreProperty]
    public double Carbohydrate { get; set; }

    [FirestoreProperty]
    public double Fiber { get; set; }

    [FirestoreProperty]
    public double Sugar { get; set; }

    [FirestoreProperty]
    public double Starch { get; set; }

    [FirestoreProperty]
    public double TotalFat { get; set; }

    [FirestoreProperty]
    public double TotalSaturatedFat { get; set; }

    [FirestoreProperty]
    public double TotalTransFat { get; set; }

    [FirestoreProperty]
    public double TotalMonounsaturated { get; set; }

    [FirestoreProperty]
    public double TotalPolyunsaturated { get; set; }

    [FirestoreProperty]
    public double Cholesterol { get; set; }

    //Vitamins
    [FirestoreProperty]
    public double VitaminA { get; set; }

    [FirestoreProperty]
    public double Thiamin { get; set; }

    [FirestoreProperty]
    public double Riboflavin { get; set; }

    [FirestoreProperty]
    public double Niacin { get; set; }

    [FirestoreProperty]
    public double PantothenicAcid { get; set; }

    [FirestoreProperty]
    public double VitaminB6 { get; set; }

    [FirestoreProperty]
    public double Biotin { get; set; }

    [FirestoreProperty]
    public double Folate { get; set; }

    [FirestoreProperty]
    public double VitaminB12 { get; set; }

    [FirestoreProperty]
    public double VitaminC { get; set; }

    [FirestoreProperty]
    public double Choline { get; set; }

    [FirestoreProperty]
    public double VitaminD { get; set; }

    [FirestoreProperty]
    public double VitaminE { get; set; }

    [FirestoreProperty]
    public double VitaminK1 { get; set; }

    [FirestoreProperty]
    public double VitaminK2 { get; set; }

    //Minerals
    [FirestoreProperty]
    public double Calcium { get; set; }

    [FirestoreProperty]
    public double Chromium { get; set; }

    [FirestoreProperty]
    public double Copper { get; set; }

    [FirestoreProperty]
    public double Fluoride { get; set; }

    [FirestoreProperty]
    public double Iodine { get; set; }

    [FirestoreProperty]
    public double Iron { get; set; }

    [FirestoreProperty]
    public double Magnesium { get; set; }

    [FirestoreProperty]
    public double Manganese { get; set; }

    [FirestoreProperty]
    public double Molybdenum { get; set; }

    [FirestoreProperty]
    public double Nickel { get; set; }

    [FirestoreProperty]
    public double Phosphorus { get; set; }

    [FirestoreProperty]
    public double Potassium { get; set; }

    [FirestoreProperty]
    public double Selenium { get; set; }

    [FirestoreProperty]
    public double Sodium { get; set; }

    [FirestoreProperty]
    public double Zinc { get; set; }

    //Amino Acids
    [FirestoreProperty]
    public double Alanine { get; set; }

    [FirestoreProperty]
    public double Arginine { get; set; }

    [FirestoreProperty]
    public double Asparagine { get; set; }

    [FirestoreProperty]
    public double AsparticAcid { get; set; }

    [FirestoreProperty]
    public double Cystine { get; set; }

    [FirestoreProperty]
    public double GlutamicAcid { get; set; }

    [FirestoreProperty]
    public double Glutamine { get; set; }

    [FirestoreProperty]
    public double Glycine { get; set; }

    [FirestoreProperty]
    public double Histidine { get; set; }

    [FirestoreProperty]
    public double Isoleucine { get; set; }

    [FirestoreProperty]
    public double Leucine { get; set; }

    [FirestoreProperty]
    public double Lysine { get; set; }

    [FirestoreProperty]
    public double Methionine { get; set; }

    [FirestoreProperty]
    public double Phenylalanine { get; set; }

    [FirestoreProperty]
    public double Proline { get; set; }

    [FirestoreProperty]
    public double Serine { get; set; }

    [FirestoreProperty]
    public double Threonine { get; set; }

    [FirestoreProperty]
    public double Tryptophan { get; set; }

    [FirestoreProperty]
    public double Tyrosine { get; set; }

    [FirestoreProperty]
    public double Valine { get; set; }

    //Other
    [FirestoreProperty]
    public double CaroteneAlpha { get; set; }

    [FirestoreProperty]
    public double CaroteneBeta { get; set; }

    [FirestoreProperty]
    public double CryptoxanthinBeta { get; set; }

    [FirestoreProperty]
    public double LuteinZeaxanthin { get; set; }

    [FirestoreProperty]
    public double Lycopene { get; set; }

    [FirestoreProperty]
    public double Theobromine { get; set; }
}
