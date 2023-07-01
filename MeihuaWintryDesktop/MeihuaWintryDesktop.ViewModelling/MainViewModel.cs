using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace MeihuaWintryDesktop.ViewModelling;

public sealed partial class MainViewModel : ObservableObject, IViewModel
{
    // TODO: 把 setter 设为 private 。
    [ObservableProperty]
    private bool isClosed;

    // TODO: 把 setter 设为 private 。
    [ObservableProperty]
    private IViewModel? popupView;

    [ObservableProperty]
    public bool canClose;

    [RelayCommand(CanExecute = nameof(CanRequestCloseExecute))]
    private void RequestClose()
    {
        if (this.CanClose)
        {
            this.IsClosed = true;
            return;
        }

        var popup = new MessagePopupViewModel("你确定要退出么？", "确定", "取消");
        popup.Choosed += (sender, e) => {
            if (this.PopupView == sender)
                this.PopupView = null;
            if (e.IsYes)
                this.IsClosed = true;
        };
        this.PopupView = popup;
    }
    private bool CanRequestCloseExecute()
    {
        return !this.IsClosed;
    }
}
