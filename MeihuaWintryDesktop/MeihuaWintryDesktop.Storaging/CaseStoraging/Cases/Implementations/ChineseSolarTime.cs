using System.Diagnostics;
using YiJingFramework.PrimitiveTypes;

namespace MeihuaWintryDesktop.Storaging.CaseStoraging.Cases.Implementations;

internal sealed class ChineseSolarTime : IChineseSolarTime
{
    public required Tiangan? YearGan { get; set; }
    public required Dizhi? YearZhi { get; set; }
    public required Tiangan? MonthGan { get; set; }
    public required Dizhi? MonthZhi { get; set; }
    public required Tiangan? DayGan { get; set; }
    public required Dizhi? DayZhi { get; set; }
    public required Tiangan? TimeGan { get; set; }
    public required Dizhi? TimeZhi { get; set; }

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

    public static ChineseSolarTime Empty
    {
        get
        {
            return new() {
                YearGan = null,
                MonthGan = null,
                DayGan = null,
                TimeGan = null,
                YearZhi = null,
                MonthZhi = null,
                DayZhi = null,
                TimeZhi = null,
            };
        }
    }

    public static ChineseSolarTime FromInterfaceType(IChineseSolarTime t)
    {
        return new ChineseSolarTime() {
            YearGan = t.YearGan,
            MonthGan = t.MonthGan,
            DayGan = t.DayGan,
            TimeGan = t.TimeGan,
            YearZhi = t.YearZhi,
            MonthZhi = t.MonthZhi,
            DayZhi = t.DayZhi,
            TimeZhi = t.TimeZhi
        };
    }
}
