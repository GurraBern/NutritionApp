using Google.Cloud.Firestore;

namespace Nutrition.Core;

[FirestoreData]
public class BodyMeasurement
{
    [FirestoreProperty]
    public double Height { get; set; }

    [FirestoreProperty]
    public double Weight { get; set; }

    [FirestoreProperty]
    public DateTime DateTime { get; set; } = DateTime.UtcNow;
}