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
}
