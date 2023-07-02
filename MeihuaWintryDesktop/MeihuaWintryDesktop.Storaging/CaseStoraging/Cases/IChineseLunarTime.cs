using YiJingFramework.PrimitiveTypes;

namespace MeihuaWintryDesktop.Storaging.CaseStoraging.Cases;

public interface IChineseLunarTime
{
    Tiangan? YearGan { get; }
    Dizhi? YearZhi { get; }

    int? Month { get; }

    int? Day { get; }

    Tiangan? TimeGan { get; }
    Dizhi? TimeZhi { get; }
}
