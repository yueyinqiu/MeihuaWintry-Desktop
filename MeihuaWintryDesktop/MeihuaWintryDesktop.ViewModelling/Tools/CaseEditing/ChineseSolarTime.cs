using MeihuaWintryDesktop.Storaging.CaseStoraging.Cases;
using YiJingFramework.PrimitiveTypes;

namespace MeihuaWintryDesktop.ViewModelling.Tools.CaseEditing;
internal sealed record ChineseSolarTime(
    Tiangan? YearGan, Dizhi? YearZhi,
    Tiangan? MonthGan, Dizhi? MonthZhi,
    Tiangan? DayGan, Dizhi? DayZhi,
    Tiangan? TimeGan, Dizhi? TimeZhi
    ) : IStoredChineseSolarTime
{
    public ChineseSolarTime(IStoredChineseSolarTime time)
        : this(time.YearGan, time.YearZhi,
              time.MonthGan, time.MonthZhi,
              time.DayGan, time.DayZhi,
              time.TimeGan, time.TimeZhi)
    {
    }
}
