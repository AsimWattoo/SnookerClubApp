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
                d = Math.Round(d, 2);
                return parameter == null ? string.Format("£{0:0.00#}/hr", d) : string.Format("£{0:0.00#}", d);
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
