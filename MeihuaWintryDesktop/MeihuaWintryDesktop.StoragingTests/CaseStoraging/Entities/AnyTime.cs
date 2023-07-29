using MeihuaWintryDesktop.Storaging.CaseStoraging.Cases;
using YiJingFramework.PrimitiveTypes;

namespace MeihuaWintryDesktop.StoragingTests.CaseStoraging.Entities;
internal class AnyTime : IStoredChineseLunarTime, IStoredChineseSolarTime, IStoredGregorianTime
{
    public Tiangan? YearGan { get; set; }

    public Dizhi? YearZhi { get; set; }

    public int? Month { get; set; }

    public bool IsLeapMonth { get; set; }

    public int? Day { get; set; }

    public Tiangan? TimeGan { get; set; }

    public Dizhi? TimeZhi { get; set; }

    public Tiangan? MonthGan { get; set; }

    public Dizhi? MonthZhi { get; set; }

    public Tiangan? DayGan { get; set; }

    public Dizhi? DayZhi { get; set; }

    public int? Year { get; set; }

    public int? Hour { get; set; }

    public int? Minute { get; set; }
}
