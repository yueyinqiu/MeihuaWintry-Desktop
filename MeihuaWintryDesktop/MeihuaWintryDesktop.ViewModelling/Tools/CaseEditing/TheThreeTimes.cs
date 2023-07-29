using Lunar;

namespace MeihuaWintryDesktop.ViewModelling.Tools.CaseEditing;
internal sealed record TheThreeTimes(
    GregorianTime Gregorian,
    ChineseSolarTime ChineseSolar, ChineseLunarTime ChineseLunar,
    DateTime? DateTime = null)
{
    public static TheThreeTimes From(DateTime dateTime)
    {
        var g = new GregorianTime(
            dateTime.Year, dateTime.Month, dateTime.Day,
            dateTime.Hour, dateTime.Minute);

        var originalDateTime = dateTime;

        if (g.Hour == 23)
            dateTime = dateTime.Add(new TimeSpan(1, 0, 0));
        var lunar = Solar.FromDate(dateTime).Lunar;

        var s = new ChineseSolarTime(
            new(lunar.YearGanIndexByLiChun + 1), new(lunar.YearZhiIndexByLiChun + 1),
            new(lunar.MonthGanIndex + 1), new(lunar.MonthZhiIndex + 1),
            new(lunar.DayGanIndex + 1), new(lunar.DayZhiIndex + 1),
            new(lunar.TimeGanIndex + 1), new(lunar.TimeZhiIndex + 1));

        var month = lunar.Month;
        var leap = month < 0;
        if (leap)
            month = -month;

        var l = new ChineseLunarTime(
            new(lunar.YearGanIndex + 1), new(lunar.YearZhiIndex + 1),
            month, leap,
            lunar.Day,
            new(lunar.TimeGanIndex + 1), new(lunar.TimeZhiIndex + 1));

        return new(g, s, l, originalDateTime);
    }
}
