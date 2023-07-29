using CommunityToolkit.Mvvm.ComponentModel;
using MeihuaWintryDesktop.Storaging.CaseStoraging.Cases;
using YiJingFramework.PrimitiveTypes;

namespace MeihuaWintryDesktop.ViewModelling.Popups.TimesSelection;

public sealed partial class SelectingChineseSolarTime : ObservableObject, IStoredChineseSolarTime
{
    [ObservableProperty]
    private Tiangan? yearGan;

    [ObservableProperty]
    private Dizhi? yearZhi;

    [ObservableProperty]
    private Tiangan? monthGan;

    [ObservableProperty]
    private Dizhi? monthZhi;

    [ObservableProperty]
    private Tiangan? dayGan;

    [ObservableProperty]
    private Dizhi? dayZhi;

    [ObservableProperty]
    private Tiangan? timeGan;

    [ObservableProperty]
    private Dizhi? timeZhi;
}