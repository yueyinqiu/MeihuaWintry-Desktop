using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using YiJingFramework.PrimitiveTypes;
using YiJingFramework.PrimitiveTypes.Serialization;

namespace MeihuaWintryDesktop.Storaging.CaseStoraging.Entities;
[JsonSerializable(typeof(JsonConverterOfStringConvertibleForJson<ChineseSolarTime>))]
public sealed class ChineseSolarTime : IStringConvertibleForJson<ChineseSolarTime>
{
    public Tiangan YearGan { get; }
    public Dizhi YearZhi { get; }
    public Tiangan MonthGan { get; }
    public Dizhi MonthZhi { get; }
    public Tiangan DayGan { get; }
    public Dizhi DayZhi { get; }
    public Tiangan TimeGan { get; }
    public Dizhi TimeZhi { get; }

    public static bool FromStringForJson(string s, [MaybeNullWhen(false)] out ChineseSolarTime result)
    {
        throw new NotImplementedException();
    }

    public string ToStringForJson()
    {
        throw new NotImplementedException();
    }
}
