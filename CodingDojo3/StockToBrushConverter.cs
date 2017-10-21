using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace CodingDojo3
{
    public class StockToBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int stock = (int)value;
            if (stock < 10) { return new SolidColorBrush(Colors.Red); }
            else if (stock > 20) { return new SolidColorBrush(Colors.Green); }
            else { return new SolidColorBrush(Colors.Yellow); }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}