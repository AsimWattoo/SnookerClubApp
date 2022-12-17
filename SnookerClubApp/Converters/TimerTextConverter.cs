using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnookerClubApp.Converters
{
    public class TimerTextConverter : BaseConverter<TimerTextConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string time)
            {
                if (time.StartsWith("-"))
                    return time.Replace("-", "+");
                else
                    return time;
            }
            return value;
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
