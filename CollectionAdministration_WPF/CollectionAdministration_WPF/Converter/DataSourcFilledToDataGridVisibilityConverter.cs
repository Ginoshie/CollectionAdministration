using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace CollectionAdministration_WPF.Converter
{
    class DataSourcFilledToDataGridVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool && 
                targetType == typeof(Visibility) &&
                (bool)value)
            {
                return Visibility.Hidden;
            }

            return Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
