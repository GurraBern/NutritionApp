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

                if (parsedDate.Date == DateTime.Now.Date)
                {
                    return "Today";
                }
                else if (parsedDate.Date == DateTime.Now.Date.AddDays(-1))
                {
                    return "Yesterday";
                }

                string formattedDate = parsedDate.ToString("dddd, dd MMM");

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