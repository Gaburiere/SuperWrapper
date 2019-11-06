using System;
using System.Globalization;
using Xamarin.Forms;

namespace SuperWrapper.Converters
{
    public class ContextSelectedToBackgroundColorConverter: IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var contextSelected = (bool) value;
            return contextSelected ? Color.Red : Color.Aqua;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}