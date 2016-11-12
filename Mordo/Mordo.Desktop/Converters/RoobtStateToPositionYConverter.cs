using Mordo.Desktop.Models;
using System;
using System.Globalization;
using System.Windows.Data;

namespace Mordo.Desktop.Converters
{
    class RobotStateToPositionYConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var robot = value as RobotState;
            if (robot == null)
                return null;
            return -(robot.PositionY * 400 / 1200);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

    }
}
