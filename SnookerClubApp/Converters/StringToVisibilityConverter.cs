using System;
using System.Globalization;
using System.Windows;

namespace SnookerClubApp.Converters
{
    public class StringToVisibilityConverter : BaseConverter<StringToVisibilityConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value == null || parameter == null)
                return Visibility.Collapsed;

            string v = value.ToString();
            string param = parameter.ToString();
            return v == param ? Visibility.Visible : Visibility.Collapsed;
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
