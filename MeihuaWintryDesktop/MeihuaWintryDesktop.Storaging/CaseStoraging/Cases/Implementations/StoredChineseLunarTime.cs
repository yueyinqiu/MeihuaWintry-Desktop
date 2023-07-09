using System.Diagnostics;
using YiJingFramework.PrimitiveTypes;

namespace MeihuaWintryDesktop.Storaging.CaseStoraging.Cases.Implementations;

internal sealed class StoredChineseLunarTime : IStoredChineseLunarTime
{
    public required Tiangan? YearGan { get; set; }
    public required Dizhi? YearZhi { get; set; }
    public required int? Month { get; set; }
    public required int? Day { get; set; }
    public required Tiangan? TimeGan { get; set; }
    public required Dizhi? TimeZhi { get; set; }

    public override string ToString()
    {
        static string GanzhiToString<T>(T? tianganOrDizhi) where T : struct, IFormattable
        {
            var result = tianganOrDizhi.HasValue ?
                tianganOrDizhi.Value.ToString("C", null)
                : "缺";
            Debug.Assert(result is not null);
            return result;
        }

        static string IntToString(int? i)
        {
            if (!i.HasValue)
                return "[null]";
            return i.Value.ToString();
        }

        return
            $"{GanzhiToString(this.YearGan)}{GanzhiToString(this.YearZhi)}年 " +
            $"{IntToString(this.Month)}月 " +
            $"{IntToString(this.Day)}日 " +
            $"{GanzhiToString(this.TimeGan)}{GanzhiToString(this.TimeZhi)}时";
    }


    public static StoredChineseLunarTime Empty
    {
        get
        {
            return new() {
                YearGan = null,
                TimeGan = null,
                YearZhi = null,
                TimeZhi = null,
                Month = null,
                Day = null
            };
        }
    }

    public static StoredChineseLunarTime FromInterfaceType(IStoredChineseLunarTime t)
    {
        return new StoredChineseLunarTime() {
            YearGan = t.YearGan,
            TimeGan = t.TimeGan,
            YearZhi = t.YearZhi,
            TimeZhi = t.TimeZhi,
            Month = t.Month,
            Day = t.Day
        };
    }
}
