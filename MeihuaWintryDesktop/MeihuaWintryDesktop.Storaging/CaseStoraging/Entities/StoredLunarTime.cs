using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using YiJingFramework.PrimitiveTypes.Serialization;

namespace MeihuaWintryDesktop.Storaging.CaseStoraging.Entities;
[JsonSerializable(typeof(JsonConverterOfStringConvertibleForJson<StoredLunarTime>))]
public sealed class StoredLunarTime : IStringConvertibleForJson<StoredLunarTime>
{
    public string ToStringForJson()
    {
        return "a";
    }

    public static bool FromStringForJson(string s, [MaybeNullWhen(false)] out StoredLunarTime result)
    {
        throw new NotImplementedException();
    }
}
