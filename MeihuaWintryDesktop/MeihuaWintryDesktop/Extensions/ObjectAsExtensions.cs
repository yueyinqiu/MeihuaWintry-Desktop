using System;

namespace MeihuaWintryDesktop.Extensions;
public static class ObjectAsExtensions
{
    public static T As<T>(this object value)
    {
        if (value is not T result)
            throw new InvalidCastException();
        return result;
    }
}
