using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MeihuaWintryDesktop.ViewModelling.Tools.PoppingUp;

namespace MeihuaWintryDesktop.ViewModelling.Popups.Message;

public sealed partial class MessagePopup : ObservableObject, IPopupViewModel
{
    internal sealed class ChoiceMadeEventArgs : EventArgs
    {
        public required bool IsYes { get; init; }
        public static ChoiceMadeEventArgs Yes { get; } = new() { IsYes = true };
        public static ChoiceMadeEventArgs No { get; } = new() { IsYes = false };
    }

    internal MessagePopup() { }

    public required PopupStack? AutoClose { get; init; }
    public required string Title { get; init; }
    public required string Message { get; init; }
    public required string? YesText { get; init; }
    public required string? NoText { get; init; }

    internal event EventHandler<ChoiceMadeEventArgs>? ChoiceMade;

    [RelayCommand]
    private void ChooseYes()
    {
        ChoiceMade?.Invoke(this, ChoiceMadeEventArgs.Yes);
        AutoClose?.Close(this);
    }

    [RelayCommand]
    private void ChooseNo()
    {
        ChoiceMade?.Invoke(this, ChoiceMadeEventArgs.No);
        AutoClose?.Close(this);
    }
}
