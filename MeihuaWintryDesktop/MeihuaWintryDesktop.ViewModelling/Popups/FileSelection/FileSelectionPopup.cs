using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MeihuaWintryDesktop.ViewModelling.Tools.PoppingUp;

namespace MeihuaWintryDesktop.ViewModelling.Popups.FileSelection;

public sealed partial class FileSelectionPopup : PopupBase, IPopupViewModel
{
    internal sealed class ChoiceMadeEventArgs : EventArgs
    {
        public required bool IsCancelled { get; init; }
        public required string EnteredPath { get; init; }
    }

    internal FileSelectionPopup(PopupStack? autoClose) : base(autoClose) { }

    public required string Title { get; init; }

    [ObservableProperty]
    private string path = "";

    internal event EventHandler<ChoiceMadeEventArgs>? ChoiceMade;

    [RelayCommand]
    private void ChooseOk()
    {
        ChoiceMade?.Invoke(this, new ChoiceMadeEventArgs() {
            EnteredPath = this.Path,
            IsCancelled = false
        });
        this.TryAutoClose();
    }

    [RelayCommand]
    private void ChooseCancel()
    {
        ChoiceMade?.Invoke(this, new ChoiceMadeEventArgs() {
            EnteredPath = this.Path,
            IsCancelled = true
        });
        this.TryAutoClose();
    }
}
