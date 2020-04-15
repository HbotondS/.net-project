using System;
using System.Globalization;
using System.Windows.Controls;
using System.Windows.Data;

namespace TMCatalog.Common.Converters
{
    public class DataGridRowNumberConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is DataGridRow)
            {
                return (value as DataGridRow).GetIndex() + 1;
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Binding.DoNothing;
        }
    }
}
