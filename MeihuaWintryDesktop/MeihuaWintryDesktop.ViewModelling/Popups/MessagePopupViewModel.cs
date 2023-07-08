using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace MeihuaWintryDesktop.ViewModelling.Popups;

public sealed partial class MessagePopupViewModel : ObservableObject, IPopupViewModel
{
    public sealed class ChoiceMadeEventArgs : EventArgs
    {
        public required bool IsYes { get; init; }
        public static ChoiceMadeEventArgs Yes { get; } = new() { IsYes = true };
        public static ChoiceMadeEventArgs No { get; } = new() { IsYes = false };
    }

    public required string Title { get; init; }
    public required string Message { get; init; }
    public required string YesText { get; init; }
    public required string? NoText { get; init; }

    public event EventHandler<ChoiceMadeEventArgs>? ChoiceMade;

    [RelayCommand]
    private void ChooseYes()
    {
        ChoiceMade?.Invoke(this, ChoiceMadeEventArgs.Yes);
    }

    [RelayCommand]
    private void ChooseNo()
    {
        ChoiceMade?.Invoke(this, ChoiceMadeEventArgs.No);
    }
}
