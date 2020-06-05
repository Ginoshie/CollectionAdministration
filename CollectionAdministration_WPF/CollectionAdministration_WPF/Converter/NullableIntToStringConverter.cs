using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace CollectionAdministration_WPF.Converter
{
    class NullableIntToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is int? && targetType == typeof(string))
            {
                return value.ToString();
            }

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string stringValue && targetType == typeof(int?))
            {
                if (int.TryParse(stringValue.Trim(), out int intValue))
                {
                    return intValue;
                }

                return null;
            }

            return null;
        }
    }
}
