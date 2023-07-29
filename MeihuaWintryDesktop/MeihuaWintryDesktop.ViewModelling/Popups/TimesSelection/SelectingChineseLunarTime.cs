using CommunityToolkit.Mvvm.ComponentModel;
using MeihuaWintryDesktop.Storaging.CaseStoraging.Cases;
using YiJingFramework.PrimitiveTypes;

namespace MeihuaWintryDesktop.ViewModelling.Popups.TimesSelection;

public sealed partial class SelectingChineseLunarTime : ObservableObject, IStoredChineseLunarTime
{
    [ObservableProperty]
    private Tiangan? yearGan;

    [ObservableProperty]
    private Dizhi? yearZhi;

    [ObservableProperty]
    private int? month;

    [ObservableProperty]
    private bool isLeapMonth;

    [ObservableProperty]
    private int? day;

    [ObservableProperty]
    private Tiangan? timeGan;

    [ObservableProperty]
    private Dizhi? timeZhi;
}