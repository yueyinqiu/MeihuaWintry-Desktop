using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace MeihuaWintryDesktop.ViewModelling;

public sealed partial class MainViewModel : ObservableObject, IViewModel
{
    // TODO: 把 setter 设为 private 。
    [ObservableProperty]
    private bool isClosed;

    [ObservableProperty]
    public bool canClose;

    [RelayCommand]
    private void RequestClose()
    {
        if (CanClose)
            this.IsClosed = true;
    }
}
