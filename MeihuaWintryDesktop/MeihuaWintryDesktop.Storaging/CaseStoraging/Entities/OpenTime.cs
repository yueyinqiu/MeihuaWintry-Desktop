using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using YiJingFramework.PrimitiveTypes.Serialization;

namespace MeihuaWintryDesktop.Storaging.CaseStoraging.Entities;
[JsonSerializable(typeof(JsonConverterOfStringConvertibleForJson<OpenTime>))]
public sealed class OpenTime : IStringConvertibleForJson<OpenTime>
{
    public DateTime Time { get; }
    public OpenTime(DateTime time)
    {
        Time = time;
    }
    public static bool FromStringForJson(string s, [MaybeNullWhen(false)] out OpenTime result)
    {
        result = new OpenTime(DateTime.Parse(s));
        if (result == null) return false;
        else return true;
    }

    public string ToStringForJson()
    {
        return Time.ToString();
    }
}