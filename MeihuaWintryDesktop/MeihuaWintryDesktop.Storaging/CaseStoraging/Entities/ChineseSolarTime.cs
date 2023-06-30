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

[JsonSerializable(typeof(JsonConverterOfStringConvertibleForJson<ChineseSolarTime>))]
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

        if (!Tiangan.TryParse(splitOfS[0], out var yearGan))
        {
            result = null;
            return false;
        }

        if (!Tiangan.TryParse(splitOfS[2], out var monthGan))
        {
            result = null;
            return false;
        }

        if (!Tiangan.TryParse(splitOfS[4], out var dayGan))
        {
            result = null;
            return false;
        }

        if (!Tiangan.TryParse(splitOfS[6], out var timeGan))
        {
            result = null;
            return false;
        }

        if (!Dizhi.TryParse(splitOfS[1], out var yearZhi))
        {
            result = null;
            return false;
        }

        if (!Dizhi.TryParse(splitOfS[3], out var monthZhi))
        {
            result = null;
            return false;
        }

        if (!Dizhi.TryParse(splitOfS[5], out var dayZhi))
        {
            result = null;
            return false;
        }

        if (!Dizhi.TryParse(splitOfS[7], out var timeZhi))
        {
            result = null;
            return false;
        }

        result = new(
            yearGan, yearZhi,
            monthGan, monthZhi,
            dayGan, dayZhi,
            timeGan, timeZhi);
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
