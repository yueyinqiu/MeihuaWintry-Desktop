using CommunityToolkit.Mvvm.ComponentModel;
using MeihuaWintryDesktop.Storaging.CaseStoraging.Cases;

namespace MeihuaWintryDesktop.ViewModelling.Popups.TimesSelection;

public sealed partial class SelectingGregorianTime : ObservableObject, IStoredGregorianTime
{
    [ObservableProperty]
    private int? year;

    [ObservableProperty]
    private int? month;

    [ObservableProperty]
    private int? day;

    [ObservableProperty]
    private int? hour;

    [ObservableProperty]
    private int? minute;
}