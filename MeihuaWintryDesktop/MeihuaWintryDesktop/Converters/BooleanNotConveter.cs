using Avalonia.Data.Converters;
using System;
using System.Globalization;

namespace MeihuaWintryDesktop.Converters;
public sealed class BooleanNotConveter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (targetType == typeof(bool))
        {
            if (value is bool b)
                return !b;
            throw new NotSupportedException("当目标类型为 bool 时，输入值必须是 bool 。");
        }
        else if (targetType == typeof(bool?))
        {
            if (value is null)
                return null;
            if (value is bool b)
                return !b;

            throw new NotSupportedException("当目标类型为 bool? 时，输入值必须是 null 或者 bool 。");
        }
        else
        {
            throw new NotSupportedException("目标类型必须是 bool 或 bool? 。");
        }
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        return this.Convert(value, targetType, parameter, culture);
    }
}
