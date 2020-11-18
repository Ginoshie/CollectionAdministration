using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using CollectionAdministration_WPF.Extensions;

namespace CollectionAdministration_WPF.Converter
{
    public class EnumToDescriptionConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value is Enum enumValue && targetType == typeof(string))
            {
                return enumValue.GetDescription();
            }

            return DependencyProperty.UnsetValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
