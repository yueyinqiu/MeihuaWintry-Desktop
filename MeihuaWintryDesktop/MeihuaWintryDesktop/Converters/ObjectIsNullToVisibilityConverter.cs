using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace MeihuaWintryDesktop.Converters;
public sealed class ObjectIsNullToVisibilityConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is null)
            return Visibility.Collapsed;
        return Visibility.Visible;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
