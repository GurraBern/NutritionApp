using System.Globalization;

namespace NutritionApp.Converters;

public class StringToDoubleConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is string stringValue)
        {
            if (double.TryParse(stringValue, CultureInfo.InvariantCulture, out double result))
            {
                return result;
            }
        }

        return 0.0;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
