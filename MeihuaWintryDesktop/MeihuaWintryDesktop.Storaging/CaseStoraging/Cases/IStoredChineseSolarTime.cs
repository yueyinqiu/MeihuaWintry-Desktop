using YiJingFramework.PrimitiveTypes;

namespace MeihuaWintryDesktop.Storaging.CaseStoraging.Cases;

public interface IStoredChineseSolarTime
{
    Tiangan? YearGan { get; }
    Dizhi? YearZhi { get; }

    Tiangan? MonthGan { get; }
    Dizhi? MonthZhi { get; }

    Tiangan? DayGan { get; }
    Dizhi? DayZhi { get; }

    Tiangan? TimeGan { get; }
    Dizhi? TimeZhi { get; }
}
