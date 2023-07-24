using MeihuaWintryDesktop.Storaging.CaseStoraging.Cases;
using YiJingFramework.PrimitiveTypes;

namespace MeihuaWintryDesktop.ViewModelling.Tools.CaseEditing;
internal sealed record ChineseLunarTime(
    Tiangan? YearGan, Dizhi? YearZhi,
    int? Month,
    int? Day,
    Tiangan? TimeGan, Dizhi? TimeZhi
    ) : IStoredChineseLunarTime
{
}
