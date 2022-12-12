using SnookerClubApp.Core.Enum;

using System;
using System.Globalization;
using System.Windows.Media;

namespace SnookerClubApp.Converters
{
    /// <summary>
    /// Converts table status to the color
    /// </summary>
    public class TableStatusToBrushConverter : BaseConverter<TableStatusToColorConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return Brushes.White;

            string? v = value.ToString();
            if(v == null)
                return Brushes.White;
            string? color = null;
            TableStatus status;
            if(Enum.TryParse<TableStatus>(v, out status))
            {
                if (status == TableStatus.Free)
                    color = "#128408";
                else
                    color = "#e5464b";
            }
            else
                return Brushes.White;

            if (color != null)
            {
                SolidColorBrush? brush = (SolidColorBrush?)new BrushConverter().ConvertFromString(color);
                return brush ?? Brushes.White;
            }
            else
                return Brushes.White;
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
