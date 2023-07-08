using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MeihuaWintryDesktop.ViewModelling.Editors;
using MeihuaWintryDesktop.ViewModelling.Sidebars;

namespace MeihuaWintryDesktop.ViewModelling;

public sealed partial class MainViewModel : ObservableObject, IPopupViewModel
{
    // TODO: 把 setter 设为 private 。
    [ObservableProperty]
    private bool isClosed;

    // TODO: 把 setter 设为 private 。
    [ObservableProperty]
    private IPopupViewModel? popup;

    // TODO: 把 setter 设为 private 。
    [ObservableProperty]
    private IEditorViewModel? editor;

    // TODO: 把 setter 设为 private 。
    [ObservableProperty]
    private ISidebarViewModel? sidebar;

    public MainViewModel()
    {
        this.IsClosed = false;
        this.Popup = null;
        this.Editor = new WelcomeEditorViewModel();
        this.Sidebar = new HistorySidebarViewModel(this);
    }

    [RelayCommand]
    private void RequestClose()
    {
        // 如果要在关闭前做一些操作（甚至取消关闭），可以在这里添加。
        this.IsClosed = true;
    }
}
