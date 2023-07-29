using CommunityToolkit.Mvvm.ComponentModel;

namespace MeihuaWintryDesktop.ViewModelling.Popups.TimesSelection;

public sealed partial class ContentSelectingDateTime : ObservableObject, ITimesSelectionPopupContent
{
    public ContentSelectingDateTime(DateTime value)
    {
        this.value = value;
    }

    [ObservableProperty]
    private DateTime value;

    public DateTime MinValue => new DateTime(1000, 1, 1);
    public DateTime MaxValue => new DateTime(8999, 12, 31);
}