using MeihuaWintryDesktop.Storaging.CaseStoraging.Cases;
using YiJingFramework.PrimitiveTypes;

namespace MeihuaWintryDesktop.ViewModelling.Tools.CaseEditing;
internal sealed record ChineseLunarTime(
    Tiangan? YearGan, Dizhi? YearZhi,
    int? Month, bool IsLeapMonth,
    int? Day,
    Tiangan? TimeGan, Dizhi? TimeZhi
    ) : IStoredChineseLunarTime
{
    public ChineseLunarTime(IStoredChineseLunarTime time)
        : this(time.YearGan, time.YearZhi,
              time.Month, time.IsLeapMonth,
              time.Day,
              time.TimeGan, time.TimeZhi)
    {
    }
}
