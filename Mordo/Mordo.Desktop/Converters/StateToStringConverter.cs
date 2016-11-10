using System;
using System.Globalization;
using System.Windows.Data;

namespace Mordo.Desktop.Converters
{
    class StateToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var state = value as int?;
            if (!state.HasValue)
                return null;
            switch (state.Value)
            {
                case -1:
                    return "STATE_INIT";
                case 0:
                    return "STATE_STOP";
                case 1:
                    return "STATE_GO";
                case 2:
                    return "STATE_ROTATE";
                case 3:
                    return "STATE_TAKE_CAN";
                case 4:
                    return "STATE_LEAVE_CAN";
                case 5:
                    return "STATE_MANUAL";
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
