using Google.Cloud.Firestore;

namespace Nutrition.Core;

[FirestoreData]
public class BodyMeasurements
{
    [FirestoreProperty]
    public double Height { get; set; }

    [FirestoreProperty]
    public double Weight { get; set; }
}