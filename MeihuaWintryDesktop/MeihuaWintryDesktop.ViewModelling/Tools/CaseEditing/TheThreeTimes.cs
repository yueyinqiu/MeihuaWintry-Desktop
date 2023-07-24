using Lunar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeihuaWintryDesktop.ViewModelling.Tools.CaseEditing;
internal sealed record TheThreeTimes(
    GregorianTime GregorianTime,
    ChineseSolarTime ChineseSolarTime, ChineseLunarTime ChineseLunarTime)
{
    public static TheThreeTimes From(
        GregorianTime GregorianTime,
        ChineseSolarTime ChineseSolarTime, ChineseLunarTime ChineseLunarTime)
    {
        return new(GregorianTime, ChineseSolarTime, ChineseLunarTime);
    }

    public static TheThreeTimes From(DateTime dateTime)
    {
        var g = new GregorianTime(
            dateTime.Year, dateTime.Month, dateTime.Day,
            dateTime.Hour, dateTime.Minute);

        if (g.Hour == 23)
            dateTime = dateTime.Add(new TimeSpan(1, 0, 0));
        var lunar = Solar.FromDate(dateTime).Lunar;

        var s = new ChineseSolarTime(
            new(lunar.YearGanIndexByLiChun + 1), new(lunar.YearZhiIndexByLiChun + 1),
            new(lunar.MonthGanIndex), new(lunar.MonthZhiIndex),
            new(lunar.DayGanIndex), new(lunar.DayZhiIndex),
            new(lunar.TimeGanIndex), new(lunar.TimeZhiIndex));

        var l = new ChineseLunarTime(
            new(lunar.YearGanIndex + 1), new(lunar.YearZhiIndex + 1),
            lunar.Month,
            lunar.Day,
            new(lunar.TimeGanIndex), new(lunar.TimeZhiIndex));

        return new(g, s, l);
    }
}
