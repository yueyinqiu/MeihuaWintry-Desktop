using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MeihuaWintryDesktop.ViewModelling.Tools.CaseEditing;
using MeihuaWintryDesktop.ViewModelling.Tools.PoppingUp;

namespace MeihuaWintryDesktop.ViewModelling.Popups.TimesSelection;

public sealed partial class TimeSelectionPopup : PopupBase, IPopupViewModel
{
    internal sealed class ChoiceMadeEventArgs : EventArgs
    {
        public required bool IsCancelled { get; init; }
        public required TheThreeTimes SelectedTime { get; init; }
    }

    internal TimeSelectionPopup(PopupStack? autoClose, TheThreeTimes? times = null)
        : base(autoClose)
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
                return this.contentSelectingDateTime;
            else
                return this.contentSelectingThreeTimes;
        }
    }

    internal event EventHandler<ChoiceMadeEventArgs>? ChoiceMade;

    private void InvokeChoiceMade(bool isCancelled)
    {
        TheThreeTimes times;
        if (this.AutomaticallyGenerateChineseTimes)
        {
            times = TheThreeTimes.From(this.contentSelectingDateTime.Value);
        }
        else
        {
            times = new TheThreeTimes(
                new(this.contentSelectingThreeTimes.Gregorian),
                new(this.contentSelectingThreeTimes.ChineseSolar),
                new(this.contentSelectingThreeTimes.ChineseLunar));
        }

        ChoiceMade?.Invoke(this, new ChoiceMadeEventArgs() {
            SelectedTime = times,
            IsCancelled = isCancelled
        });

        this.TryAutoClose();
    }

    [RelayCommand]
    private void ChooseOk()
    {
        this.InvokeChoiceMade(false);
    }

    [RelayCommand]
    private void ChooseCancel()
    {
        this.InvokeChoiceMade(true);
    }
}
