using MeihuaWintryDesktop.Storaging.CaseStoraging.Cases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
