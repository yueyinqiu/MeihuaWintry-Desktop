using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using YiJingFramework.PrimitiveTypes.Serialization;
using YiJingFramework.PrimitiveTypes;

namespace MeihuaWintryDesktop.Storaging.CaseStoraging.Entities;
[JsonSerializable(typeof(JsonConverterOfStringConvertibleForJson<ChineseLunarTime>))]
public sealed class ChineseLunarTime : IStringConvertibleForJson<ChineseLunarTime>
{
    public int LunarMonth;
    public int LunarDay;
    public string ToStringForJson()
    {
        return "a";
    }

    public static bool FromStringForJson(string s, [MaybeNullWhen(false)] out ChineseLunarTime result)
    {
        throw new NotImplementedException();
    }
}
