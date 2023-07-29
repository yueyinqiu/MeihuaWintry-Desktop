using CommunityToolkit.Mvvm.ComponentModel;
using MeihuaWintryDesktop.Storaging.CaseStoraging.Cases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeihuaWintryDesktop.ViewModelling.Popups.TimesSelection;

public sealed partial class ContentSelectingThreeTimes : ITimesSelectionPopupContent
{
    public ContentSelectingThreeTimes(
        IStoredGregorianTime gregorian,
        IStoredChineseSolarTime chineseSolar,
        IStoredChineseLunarTime chineseLunar)
    {
        this.Gregorian = new SelectingGregorianTime() {
            Year = gregorian.Year,
            Month = gregorian.Month,
            Day = gregorian.Day,
            Hour = gregorian.Hour,
            Minute = gregorian.Minute,
        };

        this.ChineseSolar = new SelectingChineseSolarTime() {
            YearGan = chineseSolar.YearGan,
            MonthGan = chineseSolar.MonthGan,
            DayGan = chineseSolar.DayGan,
            TimeGan = chineseSolar.TimeGan,
            YearZhi = chineseSolar.YearZhi,
            MonthZhi = chineseSolar.MonthZhi,
            DayZhi = chineseSolar.DayZhi,
            TimeZhi = chineseSolar.TimeZhi,
        };

        this.ChineseLunar = new SelectingChineseLunarTime() {
            YearGan = chineseLunar.YearGan,
            Month = chineseLunar.Month,
            Day = chineseLunar.Day,
            TimeGan = chineseLunar.TimeGan,
            YearZhi = chineseLunar.YearZhi,
            IsLeapMonth = chineseLunar.IsLeapMonth,
            TimeZhi = chineseLunar.TimeZhi,
        };
    }

    public SelectingGregorianTime Gregorian { get; }
    public SelectingChineseSolarTime ChineseSolar { get; }
    public SelectingChineseLunarTime ChineseLunar { get; }
}