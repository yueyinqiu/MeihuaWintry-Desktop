using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using YiJingFramework.PrimitiveTypes;
using YiJingFramework.PrimitiveTypes.Serialization;

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
