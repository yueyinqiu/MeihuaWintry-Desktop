using CommunityToolkit.Mvvm.ComponentModel;
using MeihuaWintryDesktop.Storaging.CaseStoraging;

namespace MeihuaWintryDesktop.ViewModelling.Sidebars;

public sealed partial class HistorySidebarViewModel : SidebarViewModelBase, ISidebarViewModel
{
    internal HistorySidebarViewModel(MainViewModel mainViewModel) : base(mainViewModel)
    {
    }

    protected override CaseStore? GetStoreIfExists()
    {
        return null;
    }
}
