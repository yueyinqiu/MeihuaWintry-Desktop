using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MeihuaWintryDesktop.Storaging.GlobalConfiguring;
using MeihuaWintryDesktop.ViewModelling.Editors;
using MeihuaWintryDesktop.ViewModelling.Popups;
using MeihuaWintryDesktop.ViewModelling.Sidebars;
using MeihuaWintryDesktop.ViewModelling.Tools.Disposing;
using MeihuaWintryDesktop.ViewModelling.Tools.ParameterizedStarting;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

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

    internal MainViewModel(MessagePopup errorPopup)
    {
        this.IsClosed = false;
        errorPopup.ChoiceMade += (_, _) => this.IsClosed = true;
        this.Popup = errorPopup;
    }

    internal MainViewModel(
        GlobalConfiguration globalConfiguration,
        StartingArguments startingArguments,
        MessagePopup? warningPopup = null)
    {
        this.IsClosed = false;
        this.Editor = new WelcomeEditor();
        this.Sidebar = new HistorySidebar(this, globalConfiguration);
        this.Popup = warningPopup;
    }

    [RelayCommand]
    private void RequestClose()
    {
        // 如果要在关闭前做一些操作，可以在这里添加。
        this.IsClosed = true;
    }
}
