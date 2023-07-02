using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using YiJingFramework.PrimitiveTypes;
using YiJingFramework.PrimitiveTypes.Serialization;

namespace MeihuaWintryDesktop.Storaging.CaseStoraging.Entities;

[JsonConverter(typeof(JsonConverterOfStringConvertibleForJson<ChineseSolarTime>))]
public sealed record ChineseSolarTime(
    Tiangan? YearGan, Dizhi? YearZhi,
    Tiangan? MonthGan, Dizhi? MonthZhi,
    Tiangan? DayGan, Dizhi? DayZhi,
    Tiangan? TimeGan, Dizhi? TimeZhi) 
    : IStringConvertibleForJson<ChineseSolarTime>
{
    public static bool FromStringForJson(
        string s,
        [MaybeNullWhen(false)] out ChineseSolarTime result)
    {
        var splitOfS = s.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        if (splitOfS.Length is not 8)
        {
            result = null;
            return false;
        }

        static Tiangan? ParseTiangan(string s)
        {
            if (Tiangan.TryParse(s, out var t))
                return t;
            else return null;
        }
        static Dizhi? ParseDizhi(string s)
        {
            if (Dizhi.TryParse(s, out var d))
                return d;
            else
                return null;
        }

        result = new(
            ParseTiangan(splitOfS[0]), ParseDizhi(splitOfS[1]),
            ParseTiangan(splitOfS[2]), ParseDizhi(splitOfS[3]),
            ParseTiangan(splitOfS[4]), ParseDizhi(splitOfS[5]),
            ParseTiangan(splitOfS[6]), ParseDizhi(splitOfS[7]));
        return true;
    }

    public string ToStringForJson()
    {
        static string ToString<T>(T? tianganOrDizhi) where T : struct
        {
            var result = tianganOrDizhi.HasValue ? tianganOrDizhi.Value.ToString() : "Null";
            Debug.Assert(result is not null);
            return result;
        }
        return
            $"{ToString(this.YearGan)} {ToString(this.YearZhi)} " +
            $"{ToString(this.MonthGan)} {ToString(this.MonthZhi)} " +
            $"{ToString(this.DayGan)} {ToString(this.DayZhi)} " +
            $"{ToString(this.TimeGan)} {ToString(this.TimeZhi)}";
    }

    public override string ToString()
    {
        static string ToString<T>(T? tianganOrDizhi) where T : struct, IFormattable
        {
            var result = tianganOrDizhi.HasValue ?
                tianganOrDizhi.Value.ToString("C", null)
                : "缺";
            Debug.Assert(result is not null);
            return result;
        }

        return
            $"{ToString(this.YearGan)}{ToString(this.YearZhi)}年 " +
            $"{ToString(this.MonthGan)}{ToString(this.MonthZhi)}月 " +
            $"{ToString(this.DayGan)}{ToString(this.DayZhi)}日 " +
            $"{ToString(this.TimeGan)}{ToString(this.TimeZhi)}时";
    }
}
