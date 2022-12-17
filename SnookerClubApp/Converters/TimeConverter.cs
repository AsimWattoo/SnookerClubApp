using System;
using System.Globalization;
using System.Windows.Media;

namespace SnookerClubApp.Converters
{
    public class TimeConverter : BaseConverter<TimeConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool b)
            {
                return b ? Brushes.Red : Brushes.Black;
            }
            else
                return Brushes.Black;
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
