using MeihuaWintryDesktop.Storaging.CaseStoraging.Cases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
