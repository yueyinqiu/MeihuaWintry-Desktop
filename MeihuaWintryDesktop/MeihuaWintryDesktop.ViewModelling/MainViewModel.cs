﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MeihuaWintryDesktop.Storaging.GlobalConfiguring;
using MeihuaWintryDesktop.ViewModelling.Editors;
using MeihuaWintryDesktop.ViewModelling.Editors.Welcome;
using MeihuaWintryDesktop.ViewModelling.Popups;
using MeihuaWintryDesktop.ViewModelling.Popups.Message;
using MeihuaWintryDesktop.ViewModelling.Sidebars;
using MeihuaWintryDesktop.ViewModelling.Sidebars.History;
using MeihuaWintryDesktop.ViewModelling.Tools.Disposing;
using MeihuaWintryDesktop.ViewModelling.Tools.ParameterizedStarting;
using MeihuaWintryDesktop.ViewModelling.Tools.PoppingUp;

namespace MeihuaWintryDesktop.ViewModelling;

public sealed partial class MainViewModel : ObservableObject, IPopupContext, IMainContext
{
    [ObservableProperty]
    private bool isClosed = false;

    [ObservableProperty]
    private IPopupViewModel? popup;

    private readonly PopupStack popupStack;
    PopupStack IMainContext.PopupStack => this.popupStack;

    [ObservableProperty]
    private IEditorViewModel? editor;

    [ObservableProperty]
    private ISidebarViewModel? sidebar;

    internal MainViewModel(MessagePopup errorPopup)
    {
        this.popupStack = new PopupStack(this);

        errorPopup.ChoiceMade += (_, _) => this.IsClosed = true;
        this.popupStack.Popup(errorPopup);
    }

    internal MainViewModel(
        DisposableManager disposableManager,
        GlobalConfiguration globalConfiguration,
        StartingArguments startingArguments)
    {
        this.popupStack = new PopupStack(this);

        this.Editor = new WelcomeEditor();
        this.Sidebar = new HistorySidebar(this, disposableManager, globalConfiguration);

        if (startingArguments.StartingStore is not null)
        {
            var sidebar = (SidebarBase)this.Sidebar;
            sidebar.OpenStoreOrShowPopup(startingArguments.StartingStore);
        }
    }

    [RelayCommand]
    private void RequestClose()
    {
        // 如果要在关闭前做一些操作，可以在这里添加。
        this.IsClosed = true;
    }
}
