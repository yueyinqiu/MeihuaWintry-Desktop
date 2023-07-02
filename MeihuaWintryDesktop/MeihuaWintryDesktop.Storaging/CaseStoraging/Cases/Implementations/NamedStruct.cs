using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using YiJingFramework.PrimitiveTypes;

namespace MeihuaWintryDesktop.Storaging.CaseStoraging.Cases.Implementations;
internal sealed class NamedStruct<T> : INamed<T> where T : struct
{
    public required string? Name { get; set; }
    string INamed<T>.Name => this.Name ?? "";

    public required T Value { get; set; }

    public override string ToString()
    {
        return $"{this.Name}: {this.Value}";
    }

    public static NamedStruct<T> FromInterfaceType(INamed<T> t)
    {
        return new NamedStruct<T>() {
            Name = t.Name,
            Value = t.Value
        };
    }
}
