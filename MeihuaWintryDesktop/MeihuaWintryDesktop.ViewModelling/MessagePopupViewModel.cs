using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace MeihuaWintryDesktop.ViewModelling;

public sealed partial class MessagePopupViewModel : ObservableObject, IViewModel
{
    public sealed class MessagePopupButtonClickedEventArgs : EventArgs
    {
        public required bool IsYes { get; init; }
        public static MessagePopupButtonClickedEventArgs Yes { get; } = new() { IsYes = true };
        public static MessagePopupButtonClickedEventArgs No { get; } = new() { IsYes = false };
    }

    public MessagePopupViewModel(string title, string message, string yesText, string? noText = null)
    {
        this.Title = title;
        this.Message = message;
        this.YesText = yesText;
        this.NoText = noText;
    }

    public string Title { get; }
    public string Message { get; }
    public string YesText { get; }
    public string? NoText { get; }

    public event EventHandler<MessagePopupButtonClickedEventArgs>? Choosed;

    // TODO: 把 setter 设为 private 。
    [ObservableProperty]
    private bool hasChoosed;

    public void Reset()
    {
        this.HasChoosed = false;
    }

    [RelayCommand(CanExecute = nameof(CanChooseYesExecute))]
    private void ChooseYes()
    {
        this.HasChoosed = true;
        Choosed?.Invoke(this, MessagePopupButtonClickedEventArgs.Yes);
    }
    public bool CanChooseYesExecute()
    {
        return !this.HasChoosed;
    }

    [RelayCommand(CanExecute = nameof(CanChooseNoExecute))]
    private void ChooseNo()
    {
        this.HasChoosed = true;
        Choosed?.Invoke(this, MessagePopupButtonClickedEventArgs.No);
    }
    public bool CanChooseNoExecute()
    {
        return !this.HasChoosed && this.NoText is not null;
    }
}
