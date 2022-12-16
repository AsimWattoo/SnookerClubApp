using System;
using System.Globalization;

namespace SnookerClubApp.Converters
{
    /// <summary>
    /// Converts price from number to /hr format
    /// </summary>
    public class PriceConverter : BaseConverter<PriceConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is double d)
            {
                return parameter == null ? $"£{d}/hr" : $"£{d}";
			}
            else
            {
                return "£0/hr";
            }
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
