using SnookerClubApp.Core.Enum;

using System;
using System.Globalization;
using System.Windows.Media;

namespace SnookerClubApp.Converters
{
    /// <summary>
    /// Converts table status to the color
    /// </summary>
    public class TableStatusToColorConverter : BaseConverter<TableStatusToColorConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return "#FFF";

            string? v = value.ToString();
            if(v == null)
                return "#FFF";

            TableStatus status;
            if(Enum.TryParse<TableStatus>(v, out status))
            {
                if (status == TableStatus.Free)
                    return "#128408";
                else
                    return "#e5464b";
            }
            else
                return "#FFF";
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
