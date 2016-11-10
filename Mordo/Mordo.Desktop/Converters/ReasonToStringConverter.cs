using System;
using System.Globalization;
using System.Windows.Data;

namespace Mordo.Desktop.Converters
{
    class ReasonToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var reason = value as int?;
            if (!reason.HasValue)
                return null;
            switch (reason.Value)
            {
                case 0:
                    return "PROGRAM_RESET";
                case 1:
                    return "VARIABLES_INITIALIZED";
                case 2:
                    return "BIG_ANGLE_TO_NEXT_CROSSROAD";
                case 3:
                    return "ARRIVED_AT_BASELINE";
                case 4:
                    return "CAN_DETECTED_SHARP";
                case 5:
                    return "BUTTON_PRESSED";
                default:
                    return "";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
