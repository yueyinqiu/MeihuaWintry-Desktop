using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MeihuaWintryDesktop.ViewModelling.Tools.CaseEditing;
using MeihuaWintryDesktop.ViewModelling.Tools.PoppingUp;

namespace MeihuaWintryDesktop.ViewModelling.Popups.TimesSelection;

public sealed partial class TimeSelectionPopup : ObservableObject, IPopupViewModel
{
    internal sealed class ChoiceMadeEventArgs : EventArgs
    {
        public required bool IsCancelled { get; init; }
        public required TheThreeTimes SelectedTime { get; init; }
    }

    internal TimeSelectionPopup(TheThreeTimes? times = null)
    {
        times ??= TheThreeTimes.From(DateTime.Now);

        this.contentSelectingDateTime = new(
            times.DateTime ?? DateTime.Now);

        this.contentSelectingThreeTimes = new(
            times.Gregorian,
            times.ChineseSolar,
            times.ChineseLunar);

        this.AutomaticallyGenerateChineseTimes = times.DateTime is not null;
    }

    public required PopupStack AutoClose { get; init; }
    public required string Title { get; init; }

    private readonly ContentSelectingDateTime contentSelectingDateTime;
    private readonly ContentSelectingThreeTimes contentSelectingThreeTimes;

    [NotifyPropertyChangedFor(nameof(Content))]
    [ObservableProperty]
    private bool automaticallyGenerateChineseTimes;

    public ITimesSelectionPopupContent Content
    {
        get
        {
            if (this.AutomaticallyGenerateChineseTimes)
                return contentSelectingDateTime;
            else
                return contentSelectingThreeTimes;
        }
    }

    internal event EventHandler<ChoiceMadeEventArgs>? ChoiceMade;

    private void InvokeChoiceMade(bool isCancelled)
    {
        TheThreeTimes times;
        if (this.AutomaticallyGenerateChineseTimes)
        {
            times = TheThreeTimes.From(contentSelectingDateTime.Value);
        }
        else
        {
            times = new TheThreeTimes(
                new(contentSelectingThreeTimes.Gregorian),
                new(contentSelectingThreeTimes.ChineseSolar),
                new(contentSelectingThreeTimes.ChineseLunar));
        }

        ChoiceMade?.Invoke(this, new ChoiceMadeEventArgs() {
            SelectedTime = times,
            IsCancelled = isCancelled
        });

        AutoClose?.Close(this);
    }

    [RelayCommand]
    private void ChooseOk()
    {
        InvokeChoiceMade(false);
    }

    [RelayCommand]
    private void ChooseCancel()
    {
        InvokeChoiceMade(true);
    }
}
