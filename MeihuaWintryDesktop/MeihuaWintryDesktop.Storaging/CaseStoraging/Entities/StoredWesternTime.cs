using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using YiJingFramework.PrimitiveTypes.Serialization;

namespace MeihuaWintryDesktop.Storaging.CaseStoraging.Entities;
[JsonSerializable(typeof(JsonConverterOfStringConvertibleForJson<StoredWesternTime>))]
public sealed class StoredWesternTime : IStringConvertibleForJson<StoredWesternTime>
{
    public string ToStringForJson()
    {
        // 把 StoredWesternTime 转换成字符串返回
        throw new NotImplementedException();
    }

    public static bool FromStringForJson(
        string s,
        [MaybeNullWhen(false)] out StoredWesternTime result)
    {
        // 把 s 转换成 StoredWesternTime ，存在 result 里，然后返回 true
        // 若转换失败，则赋值 result = null ，然后返回 false
        throw new NotImplementedException();
    }
}
