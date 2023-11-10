using System.Globalization;

namespace NutritionApp.Converters
{
    public class DateToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string date)
            {
                DateTime parsedDate = DateTime.ParseExact(date, "yyyy-MM-dd", null);

                string formattedDate = parsedDate.ToString("dddd, dd MMMM");
                return formattedDate;
            }

            return string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}