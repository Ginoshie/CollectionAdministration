using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace CollectionAdministration_WPF.Converter
{
    class NullableDoubleToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is double? && targetType == typeof(string))
            {
                return value.ToString();
            }

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
