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
[JsonSerializable(typeof(JsonConverterOfStringConvertibleForJson<StoredWesternTime>))]
public sealed class StoredWesternTime : IStringConvertibleForJson<StoredWesternTime>
{
    public DateTime Time { get; }

    public StoredWesternTime(DateTime time)
    {
        Time = time;
    }

    public string ToStringForJson()
    {
        return Time.ToString();
    }

    public static bool FromStringForJson(
        string s,
        [MaybeNullWhen(false)] out StoredWesternTime result)
    {
        result = new StoredWesternTime(DateTime.Parse(s));
        if (result != null) return true;
        else return false;
    }
}
