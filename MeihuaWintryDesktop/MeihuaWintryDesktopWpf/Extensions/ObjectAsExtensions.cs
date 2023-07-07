using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeihuaWintryDesktopWpf.Extensions;
public static class ObjectAsExtensions
{
    public static T As<T>(this object value)
    {
        if (value is not T result)
            throw new InvalidCastException();
        return result;
    }
}
