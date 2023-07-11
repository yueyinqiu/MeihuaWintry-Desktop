﻿using MeihuaWintryDesktop.Storaging.CaseStoraging;

namespace MeihuaWintryDesktop.ViewModelling.Sidebars;

public sealed partial class StoreSidebarViewModel : SidebarViewModelBase, ISidebarViewModel
{
    private readonly CaseStore store;

    protected override CaseStore? GetStoreIfExists()
    {
        return this.store;
    }

    internal StoreSidebarViewModel(MainViewModel mainViewModel, CaseStore store) : base(mainViewModel)
    {
        this.store = store;
    }
}