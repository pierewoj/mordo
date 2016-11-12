using Mordo.Desktop.Models;
using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Mordo.Desktop.Converters
{
    class RobotStateToPositionXConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var robot = value as RobotState;
            if (robot == null)
                return null;
            return robot.PositionX * 400 / 1200;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

    }
}
