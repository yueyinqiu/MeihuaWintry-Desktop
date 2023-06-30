using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using YiJingFramework.PrimitiveTypes.Serialization;

namespace MeihuaWintryDesktop.Storaging.CaseStoraging.Entities;
[JsonConverter(typeof(JsonConverterOfStringConvertibleForJson<WesternTime>))]
public sealed class WesternTime : IStringConvertibleForJson<WesternTime>
{
    public DateTime Time { get; }

    public WesternTime(DateTime time)
    {
        this.Time = time;
    }

    public string ToStringForJson()
    {
        return this.Time.ToString();
    }

    public static bool FromStringForJson(
        string s,
        [MaybeNullWhen(false)] out WesternTime result)
    {
        result = new WesternTime(DateTime.Parse(s));
        if (result != null) 
            return true;
        else 
            return false;
    }
}
