using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace MeihuaWintryDesktop.ViewModelling.Popups;

public sealed partial class FileSelectionPopupViewModel : ObservableObject, IPopupViewModel
{
    public sealed class ChoiceMadeEventArgs : EventArgs
    {
        public required bool IsCancelled { get; init; }
        public required string EnteredPath { get; init; }
    }

    internal FileSelectionPopupViewModel(string title)
    {
        this.Title = title;
        this.Path = "";
    }

    public string Title { get; }

    [ObservableProperty]
    private string path;

    public event EventHandler<ChoiceMadeEventArgs>? ChoiceMade;

    [RelayCommand]
    private void ChooseOk()
    {
        ChoiceMade?.Invoke(this, new ChoiceMadeEventArgs() {
            EnteredPath = this.Path,
            IsCancelled = false
        });
    }

    [RelayCommand]
    private void ChooseCancel()
    {
        ChoiceMade?.Invoke(this, new ChoiceMadeEventArgs() {
            EnteredPath = this.Path,
            IsCancelled = true
        });
    }
}
